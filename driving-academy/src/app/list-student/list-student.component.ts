import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DrivingacademyService } from '../services/drivingacademy.service';
import { DetailStudent, Student } from '../models/Student';

@Component({
  selector: 'app-list-student',
  templateUrl: './list-student.component.html',
  styleUrls: ['./list-student.component.css'],
})
export class ListStudentComponent implements OnInit {
  students?: Student[];
  currentStudent: DetailStudent = {
    Age: 0,
    StudentId: 0,
    Name: '',
    TypeLicence: '',
    Identification: '',
    Lessons: [],
  };
  currentIndex = -1;

  constructor(
    private _academyService: DrivingacademyService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadStudents();
  }

  loadStudents(): void {
    this._academyService.getStudents().subscribe(
      (data) => {
        console.log(data);
        this.students = data;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  refreshList(): void {
    this.loadStudents();
    this.currentIndex = -1;
  }

  setActiveStudent(student: any, index: number): void {
    this._academyService.getStudentWithDetail(student.StudentId).subscribe(
      (data) => {
        this.currentStudent = data;
        console.log(this.currentStudent);
        this.currentIndex = index;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  addLesson(id: any): void {
    this.router.navigate(['/estudiantes/agregar-clases', id]);
  }
}
