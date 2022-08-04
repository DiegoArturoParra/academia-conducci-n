import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CreateStudent } from '../models/Student';
import { DrivingacademyService } from '../services/drivingacademy.service';

@Component({
  selector: 'app-form-student',
  templateUrl: './form-student.component.html',
  styleUrls: ['./form-student.component.css'],
})
export class FormStudentComponent implements OnInit {
  listaLicencias!: any[];
  student: CreateStudent = {
    Age: 0,
    Identification: '',
    Name: '',
    typeLicenceId: 0,
  };
  public valForm!: FormGroup;
  fechaActual?: Date;
  licencia?: any;
  constructor(
    private fb: FormBuilder,
    private _academyService: DrivingacademyService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.valForm = this.fb.group({
      Age: this.fb.control(null, [Validators.required]),
      Name: this.fb.control(null, [Validators.required]),
      Identification: this.fb.control(null, [Validators.required]),
      typeLicenceId: this.fb.control(0),
    });

    this.LoadLicences();
  }
  LoadLicences() {
    this._academyService.getLicences().subscribe(
      (data) => {
        this.listaLicencias = data;
        this.valForm.get('typeLicenceId')?.setValue(this.listaLicencias[0].Id);
      },
      (error) => {
        console.log(error);
      }
    );
  }
  get LicenciaId() {
    return this.valForm.get('typeLicenceId');
  }

  get Edad() {
    return this.valForm.get('Age');
  }
  get Identificacion() {
    return this.valForm.get('Identification');
  }

  get Nombre() {
    return this.valForm.get('Name');
  }

  devolver() {
    this.router.navigate(['/estudiantes']);
  }
  addStudent() {
    console.log(this.valForm.value);
    this._academyService.createStudent(this.valForm?.value).subscribe(
      (data) => {
        this.router.navigate(['/', 'estudiantes']).then(
          (nav) => {
           alert('Estudiante agregado correctamente');
          },
        );
      },
      (error) => {
        alert(error.error.Message);
      }
    );
  }
}
