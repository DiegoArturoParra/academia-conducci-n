import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormStudentComponent } from './form-student/form-student.component';
import { ListStudentComponent } from './list-student/list-student.component';
import { FormDetailComponent } from './form-detail/form-detail.component';

const routes: Routes = [
  { path: 'estudiantes', component: ListStudentComponent },
  { path: 'estudiantes/agregar', component: FormStudentComponent },
  { path: 'estudiantes/agregar-clases', component: FormDetailComponent },
  { path: 'estudiantes/agregar-clases/:studentId', component: FormDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
