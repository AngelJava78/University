import { Component, OnInit, OnDestroy } from '@angular/core';
import { Course } from 'src/app/domain/course';
import { CourseService } from 'src/app/service/course.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.css']
})
export class CoursesListComponent implements OnInit, OnDestroy {

  public courses: Course[] = [];
  public subCourses: Subscription = new Subscription;

  constructor(public courseService: CourseService) {

  }
  ngOnDestroy(): void {
    this.subCourses.unsubscribe();
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.subCourses = this.courseService.getAll().subscribe(data => {
      this.courses = data;
    });
  }

}
