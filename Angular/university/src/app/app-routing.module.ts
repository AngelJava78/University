import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CoursesListComponent } from './component/courses-list/courses-list.component';
import { CourseAllComponent } from './component/course-all/course-all.component';
import { CourseSaveComponent } from './component/course-save/course-save.component';
import { CourseEditComponent } from './component/course-edit/course-edit.component';
import { CourseDeleteComponent } from './component/course-delete/course-delete.component';

const routes: Routes = [
  { path: 'courses-list', component: CoursesListComponent },
  { path: 'course-all', component: CourseAllComponent },
  { path: 'course-save', component: CourseSaveComponent },
  { path: 'course-edit/:id', component: CourseEditComponent },
  { path: 'course-delete/:id', component: CourseDeleteComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
