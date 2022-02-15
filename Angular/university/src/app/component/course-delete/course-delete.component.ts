import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/domain/course';
import { CourseService } from 'src/app/service/course.service';

@Component({
  selector: 'app-course-delete',
  templateUrl: './course-delete.component.html',
  styleUrls: ['./course-delete.component.css']
})
export class CourseDeleteComponent implements OnInit {

  public id: number = 0;
  public course: Course = new Course(0, '', 0);

  public showMsg: boolean = false;
  public msg: string = '';
  public type: string = '';
  params: any;
  constructor(public courseService: CourseService,
    public router: Router,
    public activateRoute: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.getById();
  }

  public getById() {
    this.params = this.activateRoute.params.subscribe(
      params => {
        this.id = params['id'];
        console.log(this.id);
      }
    );
    this.courseService.getById(this.id).subscribe(data => {
      this.course = data;
    });
  }

  public delete() {
    console.log(this.course);
    this.courseService.delete(this.course.CourseID).subscribe({
      next: (v) => console.log(v),
      error: (e) => {
        console.log(e);
        this.showMsg = true;
        this.msg = 'An error has ocurred in the procedure';
        this.type = 'danger';
      },
      complete: () => {
        this.router.navigate(['/courses-list']);
      }
    })
  }

}
