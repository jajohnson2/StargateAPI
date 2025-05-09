import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateAstronautDutyRequest } from '../models/create-astronaut-duty';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  // Best practice to have a file that uses different URLs for different environments
  private apiUrl = 'https://localhost:7204';

  constructor(private http: HttpClient) { }

  getPeople(): Observable<any> {
    return this.http.get(`${this.apiUrl}/Person`);
  }

  getPersonByName(name: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/Person/${name}`);
  }

  createPerson(name: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/Person`, JSON.stringify(name), {
      headers: { 'Content-Type': 'application/json' }
    });
  }

  getAstronautDutiesByName(name: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/AstronautDuty/${name}`);
  }

  createAstronautDuty(duty: CreateAstronautDutyRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/AstronautDuty`, JSON.stringify(duty), {
      headers: { 'Content-Type': 'application/json' }
    });
  }
}
