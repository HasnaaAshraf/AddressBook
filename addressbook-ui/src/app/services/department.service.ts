import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Department {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  private baseUrl = 'https://localhost:7215/api/Department';

  constructor(private http: HttpClient) { }

  getAllDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(this.baseUrl);
  }

  getDepartmentById(id: number): Observable<Department> {
    return this.http.get<Department>(`${this.baseUrl}/${id}`);
  }

  addDepartment(department: { name: string }): Observable<any> {
    return this.http.post(this.baseUrl, department);
  }

  updateDepartment(id: number, department: { name: string }): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, department);
  }

  deleteDepartment(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}