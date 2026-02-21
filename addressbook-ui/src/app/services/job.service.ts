import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Job } from 'src/app/models/job.model';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private apiUrl = 'https://localhost:7215/api/Job';

  constructor(private http: HttpClient) {}

  getAllJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(this.apiUrl);
  }

   addJob(job: Job): Observable<Job> {
    return this.http.post<Job>(this.apiUrl, job);
  }

  updateJob(id: number, job: Job): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, job);
  }

  deleteJob(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}