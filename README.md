# BAM Technologies Coding Exercise - Implementation and Insights

This document outlines the steps I took to complete the BAM Technologies coding exercise, showing how I understood the project, got my environment set up, and my thought process as I built the required features.

1.  **Got the Project Code:** I cloned the project repository from GitHub to get a local copy to work with.
    
2.  **Set Up a GitHub Repo:** I created my own repository on GitHub. This helped with keeping track of changes and sharing the code.
    
    - All my changes followed this workflow: Feature Branch → Testing → Peer Review → Merge into Develop → Integration Testing → Merge into Main. This helps keep the code organized and makes sure everything is tested along the way.
    - Note: Usually, automated checks (CI/CD) would also run at different points in this process.
3.  **Looked over Requirements:** I carefully read the `README.md` file to understand what the project was asking for, what the rules were, and any specific things I needed to keep in mind.
    
4.  **Reviewed the Existing Code:** I went through the code that was already there to get a feel for how the application was put together, what the main parts were, and how it was supposed to work.
    
5.  **Set Up My Local Environment:** I got all the necessary things installed on my computer to work on the project, including setting up DB Browser for SQLite, as well as updating Node, npm, and Angular 19.
    
6.  **npm install:** I checked that all the required NuGet packages were installed correctly and that I had the right versions.
    
7.  **Research for Mock Data:** I looked at some publicly available astronaut databases and also studied how the `SeedData()` function in the code was set up. This helped me understand what kind of information to use, like ranks and titles, and how to make the data seem realistic.
    
8.  **Made a Bunch of Mock Data:** I created a good amount of sample data. I used AI to help me quickly get more varied data than what was there by default, which was useful for testing different situations.
    
9.  **Made Sure the Data Followed the Rules:** I made sure all data followed the rules in the README.
    
10. **Put the Data into the Code:** I turned this data into C# code and placed it inside of the existing `SeedData()` function.
    
11. **Updated the Database:** Using the NuGet package manager, I ran `Add-Migration AddSeedData` and then `Update-Database` to put the mock data into my local SQLite database. I used DB Browser for SQLite to confirm the data was there. I did notice a small issue here, which I talk about in Challenge #1.
    
12. **Spotted a Small Issue with the Database:** I noticed that `AstronautDetail.CareerStartDate` was set to be required in the code but could be empty in the initial database setup (`_InitialCreate.cs`). In a real project, I'd ask for clarification to make sure the data is right. This could cause issues if left. For this exercise, I changed the database to also require a value.
    
13. **Ignored the Database File:** I added `*.db` to the `.gitignore` file. This is a common practice.
    
14. **Tested the API Endpoints with Swagger:** I used Swagger UI to test the different API endpoints.
    
    - They were all working:
        - `GET: /AstronautDuty/{name}`
        - `GET: /Person`
        - `GET:/Person/{name}`
        - `POST: /Person`
        - `POST: /AstronautDuty` - I also confirmed that it correctly gave an error (400 Bad Request) when I tried to add a duty for someone who didn't exist in the `Person` table.
15. **Generated a New Angular App:** I ran `ng new StargateApp` to create a new Angular project inside the main StargateAPI folder.
    
16. **Enabled API Calls in Angular:** I imported `provideHttpClient` in `app.config.ts` so the Angular app could make calls to the API.
    
17. **Ran into a Node.js Problem:** I had an issue because of a wrong Node.js environment variable. More in Challenge #2.
    
18. **Another Issue with Connections:** I had another problem – this time it was because too many things were trying to use the same port. Details in Challenge #3.
    
19. **Set Up Cross-Origin Resource Sharing (CORS):** For development/testing, I had to allow Angular (localhost:4200) to make request to the backend APIs (localhost:7204). Since they are on different domains CORS is necessary. Angular has tools that make setting this up pretty simple.
    
20. **Created Several Interfaces in Angular:** I created TypeScript Interfaces for Person, Create-Person, Astronaut Duty, and Create-Astronaut-Duty. This helps keep the code organized and makes sure I'm using the right types of data.
    
21. **Started Building out API Calls in Angular:** I set up some basic functions to call the API for things like getting all people, getting a person by name, creating a person, getting astronaut duties by name, and creating an astronaut duty. I had a small issue with a couple of these, which I explain in Challenge #4.
    
22. **Made a Simple User Interface:** I created a basic HTML page to interact with the APIs. I utilized AI’s help to quickly spin up some CSS for it.
    
23. **Got 'Get Person by Name' Working:** I fixed any issues and got the API call to get a person by their name working. Does error checking in subscription block. Notifies user if person was not found via HTML.
    
24. **Got ‘Get All People’ Working:** I first had to choose if this list would populate `OnInit()` or if it would be a manual process. I landed on adding a button to allow the user to populate the list since loading this list during page initialization could be a heavy task as the project, and database, scales in size. I was able to get the API to return a list of everyone in the `People` table. It displays their `name` and their `personId`.
    
25. **Got 'Create Person' Working:** I also got the API call to create a new person working correctly. There’s currently no input validation which would need to be added in the future. An alert lets the user know that the user was successfully created and refreshes the `getAllPeople` list on the page.
    
26. **Got ‘Create Astronaut Duty’ Working:** This API call was a tiny bit more complex than the other API calls. In order to create an astronaut duty for an existing person, we first have to GET personByName to pass that to the createAstronautDuty API call. An alert is displayed to let the user know the creation was successful. I considered having this also refresh the getPersonByName display on the UI, but decided that might be overreaching. It would be easy to implement by calling getPersonByName after creating the new astronaut duty. You could even prompt the user to make the decision to fetch the person’s record after creating a new duty.
    
27. **Clean up code:** Before considering the project complete (for the time being--had to stop due to time constraint) and ready for broader testing or merging, I performed code cleanup. This involved:
    * Removing any temporary `console.log` statements used during debugging.
    * Ensuring consistent code formatting across all new and modified files
    * Removing any unused variables, imports, or dead code sections.
    * Adding or refining comments where necessary

28. **Regression testing:** With the new features implemented and cleaned up, the next step was to perform regression testing. 
    * I manually re-tested all the features that were already working before I started, including navigating to Swagger UI and using all the base API endpoints (`GET /Person`, `GET /Person/{name}`, `POST /Person`, `GET /AstronautDuty/{name}`, `POST /AstronautDuty`).
    * I also re-tested all the newly implemented UI features in the Angular app, verifying that fetching, displaying, and creating Persons and Astronaut Duties still worked as expected in various scenarios.
    * In a professional setting, this phase would heavily involve running automated unit tests and integration tests.

29. **Merge into Develop:** After the code was cleaned and regression testing passed, the `develop` branch was merged into the `main` branch.

30. **What I would do next:** Looking beyond the completion of the core requirements, here are some areas I would focus on:

    * **Automated Testing:** Implement comprehensive unit tests using a framework like NUnit or MSTest. Add unit tests for Angular. 
    * **Error Handling & Input Validation:** Enhance error handling in both the back-end (more specific API responses) and front-end (user-friendly error messages instead of just alerts). Implement input validation on the back-end for all API endpoints and add front-end validation in the Angular forms.
    * **Improve UI:** Refine the Angular UI for a better user expeience and functionality. Improve how data is displayed (e.g., data tables for lists).
    * **Handle Specific Use Cases:** Address edge cases like handling multiple people with the same name in the search functionality (e.g., returning a list to choose from).
    * **Additional API Endpoints:** Implement standard CRUD (Create, Read, Update, Delete) operations for all relevant entities.
    * **Logging:** Implement logging within the application and configure it to save logs to a database.
    * **Authentication and Authorization:** Implement security measures to ensure only authorized users can access certain APIs or perform specific actions.
    * **Configuration Settings:** Create configuration settings like connection strings, API URLs, etc.

    &nbsp;
    
    &nbsp;
    

### **Challenges Encountered:**

1.  The order of the columns in the `AstronautDetail` table looked wrong in DB Browser for SQLite.
    
    - <ins>Solution</ins>: This was a strange visual thing. The code that first created the table sets the order as *Id, PersonId, CurrentRank, CurrentDutyTitle, CareerStartDate, CareerEndDate*. But in DB Browser for SQLite, it showed as *Id, CareerEndDate, CareerStartDate, CurrentDutyTitle, CurrentRank, PersonId*. Since this was just how it looked and didn't actually change the data, I decided to come back to it later if I had time after fixing more important things.
2.  I had issues when trying to run the application with the debugger in VS 2022. The errors said: "\*AggregateException: One or more errors occurred. (The npm script 'start' exited without indicating that the Angular CLI was listening for requests. The error output was: Node.js version v14.17.0 detected.  
     -  <ins>Solution:</ins> I checked my computer's environment variables and noticed that there were two places where Node.js was listed. I made sure the system only used the newer version.
	
3.  When I was connecting the Angular part to the existing ASP.NET project, I got an error when trying to run Angular with the debugger: "*Failed to bind to address http://\[::1\]:4200: address already in use.*"
    
    -  <ins>Solution</ins>: This happened because too many things were trying to use the same address and port (`localhost:4200`).
        -  I created a new profile in `launchSettings.json` called "*Angular*" to make testing easier.
        -  Set  `"launchUrl": "https://localhost:4200"` and `"applicationUrl": "http://localhost:5204"`.
        -  I ended up battling with this back and forth for so long that I decided to just manually run `dotnet` and `ng serve` and bypass VS debugging for the sake of saving time.
		
4.  I was sending a 'name' as a string to `POST api/Person` and getting a 400 error.
    
    - <ins>Solution</ins>: After looking into it, I realized the API was expecting data in JSON format. I added `JSON.stringify` to the parameter, and it worked fine.

### **Testing Approach:**

- Swagger UI is really handy for testing APIs. You can see the status codes, make API calls and see the responses, and also look at the API documentation.
- It would be a good idea to add unit tests using a framework like MSTest or NUnit to test individual parts of the code.

### **Things to Think About:**

- In the code, `AstronautDetail.CareerStartDate` is supposed to have a value, but when the database was first created (by the `_InitialCreate.cs` file), it was set up so it *could* be empty. We need to confirm if it should always have a value or if it can sometimes be empty.
- It would be good to create an `environments` file in the Angular project to store the different API addresses for different setups (like development and production).
- The search functionality could be better. For example, it could have fuzzy searching or return a list of people if more than one person has the same name.
- It would be useful to log things like searches, successes, errors, and exceptions and save them to the database.

### **What I Learned:**

- A big thing I learned was that really understanding what the project needs is the most important first step before writing any code. Knowing the problem well makes it much easier to solve.
- Having a well-organized system with a good flow is key to working efficiently and making sure the code is accurate.
- Using AI can be super helpful for getting started, creating sample data, and doing certain tasks quickly. But you can't just trust it completely and you never want to depend on it.
- It's important to know what to focus on, especially when you don't have a lot of time. Sometimes you have to decide whether spending more time on a small issue is worth it when there are other things that need to be done.
- When you create a new Angular app with `ng new` in version 15 or later, it's set up as a standalone app by default. This means you can use Components, Directives, and Pipes without having to declare them in an NgModule. The app starts from `AppComponent` in `main.ts`.
- `HttpClientModule` is no longer recommended in Angular 18. The new way to handle API calls is with `provideHttpClient`. It helps avoid having the same providers in multiple places, simplifies how things are set up, and works better with standalone components.
- **Remembered how much fun it is to take a coding exercise and start building from the ground up.  I honestly enjoyed this experience so very much.  So thank you for that.**