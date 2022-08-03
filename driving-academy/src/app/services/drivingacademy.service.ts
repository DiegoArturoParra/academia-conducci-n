import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/Student';
@Injectable({
  providedIn: 'root',
})
export class DrivingacademyService {
  private url = `${environment.baseUrl}`;

  constructor(private http: HttpClient) {}

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.url}/list-students`);
  }

  GetLessonsByModuleId(id: any): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}/list-lessons-by-module/${id}`);
  }

  getModules(): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}/list-modules`);
  }

  getLicences(): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}/list-licences`);
  }

  getStudentWithDetail(id: any): Observable<any> {
    return this.http.get(`${this.url}/student/${id}`);
  }

  createStudent(data: any): Observable<any> {
    return this.http.post(`${this.url}/create-student`, data);
  }

  createDetail(data: any): Observable<any> {
    return this.http.post(`${this.url}/create-detail`, data);
  }
}
