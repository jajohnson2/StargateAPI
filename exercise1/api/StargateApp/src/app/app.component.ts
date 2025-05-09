import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiService } from './services/api.service';
import { Person } from './models/person';
import { AstronautDuty } from './models/astronaut-duty';
import { CreateAstronautDutyRequest } from './models/create-astronaut-duty';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'StargateApp';

  // Using factory methods to easily set and reset default values for the models
  private createDefaultPerson(): Person {
    return {
      personId: 0,
      name: ''
    };
  }

  private createDefaultAstronautDuty(): AstronautDuty {
    return {
      id: 0,
      personId: 0,
      currentRank: '',
      currentDutyTitle: '',
      careerStartDate: new Date(),
      careerEndDate: null,
      person: {
        personId: 0,
        name: ''
      }
    };
  }

  private createDefaultCreateAstronautDutyRequest(): CreateAstronautDutyRequest {
    return {
      name: '',
      rank: '',
      dutyTitle: '',
      dutyStartDate: new Date()
    };
  }

  // Person Properties
  people: Person[] = [];  
  personDetails: Person = this.createDefaultPerson();  

  // AstronautDuty Properties
  astronautDuties: AstronautDuty = this.createDefaultAstronautDuty();
  newDutyRequest: CreateAstronautDutyRequest = this.createDefaultCreateAstronautDutyRequest();

  // User Input Properties
  personNameInput: string = '';
  newPersonName: string = '';
  newDutyPersonName: string = '';
  newDutyPersonRank: string = '';
  newDutyTitle: string = '';
  newDutyStartDate: Date = new Date();

  constructor(private apiService: ApiService) { }

  ngOnInit(): void { }

  getAllPeople(): void {
    this.apiService.getPeople().subscribe({
      next: (data) => {
        this.people = data.people;
      },
      error: (error) => {
        console.error('Error fetching all people:', error);
      }
    });
  }

  getPersonDetails(): void {
    if (this.personNameInput) {
      this.apiService.getPersonByName(this.personNameInput).subscribe({
        next: (response) => {
          if (response.person) {
            this.personDetails = response.person;
            //Fetch astronaut duties for the person
            this.getPersonDuties(response.person.name);
          }
          else {
            alert('No person found with that name');
            this.personDetails = this.createDefaultPerson();
            this.astronautDuties = this.createDefaultAstronautDuty();
          }
        },
        error: (error) => {
          console.error('Error fetching person details:', error);
        }
      });
    }
  }

  getPersonDuties(name: string): void {
    this.apiService.getAstronautDutiesByName(name).subscribe({
      next: (response) => {
        // Check if the astronaut contains active duties by checking careerStartDate
        if (response.person.careerStartDate) {
          this.astronautDuties = response.person;
        }
        else {
          this.astronautDuties = this.createDefaultAstronautDuty();
        }
      },
      error: (error) => {
        console.error('Error fetching astronaut duties:', error);
      }
    });
  }

  createPerson(): void {
    if (this.newPersonName) {
      this.apiService.createPerson(this.newPersonName).subscribe({
        next: (person) => {
          alert(`Person "${this.newPersonName}" created with ID ${person.id}.  People table refreshed.`);
          this.getAllPeople();
          this.newPersonName = '';
        },
        error: (error) => {
          console.error('Error creating person:', error);
        }
      });
    }
  }

  createAstronautDuty(): void {
    // Assign user input to the new duty request
    this.newDutyRequest = {
      name: this.newDutyPersonName,
      rank: this.newDutyPersonRank,
      dutyTitle: this.newDutyTitle,
      dutyStartDate: this.newDutyStartDate
    };

    this.apiService.createAstronautDuty(this.newDutyRequest).subscribe({
      next: (response) => {
        if (response) {
          alert('Astronaut Duty created successfully.');
        }
        else {
          alert('Failed to create Astronaut Duty.');
        }
        this.newDutyRequest = this.createDefaultCreateAstronautDutyRequest();
      },
      error: (error) => {
        console.error('Error creating Astronaut Duty:', error);
      }
    });
  }
}
