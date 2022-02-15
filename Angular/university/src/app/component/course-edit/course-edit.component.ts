import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/domain/course';
import { CourseService } from 'src/app/service/course.service';


@Component({
  selector: 'app-course-edit',
  templateUrl: './course-edit.component.html',
  styleUrls: ['./course-edit.component.css']
})
export class CourseEditComponent implements OnInit {

  public course: Course = new Course(0, '', 0);
  public id: number = 0;
  public showMsg: boolean = false;
  public msg: string = '';
  public type: string = '';
  params: any;
  constructor(public courseService: CourseService,
    private router: Router,
    private activedRoute: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.getById();
  }

  public getById() {

    this.params = this.activedRoute.params.subscribe(
      params => {
        this.id = params['id'];
        console.log(this.id);
      }
    )
    this.courseService.getById(this.id).subscribe(data => {
      this.course = data;
    });
  }

  public edit() {
    console.log(this.course);

    this.courseService.edit(this.course).subscribe({
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
    });
  }
}
