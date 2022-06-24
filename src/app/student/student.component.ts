import { Component, OnInit } from '@angular/core';
import { Student } from './student';
import { StudentService } from './student.service';

declare var window: any;

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {
  addORUpdateModal: any;
  studentForm: Student = {
    age: 0,
    gender: 'Male',
    id: 0,
    name: '',
  };
  booleanValue: any = false;
  searchedKeyword: string = '';
  addorupdatemodalTitle: string = '';
  students: Student[] = [];
  deleteModal: any;
  studentIdToDelete: number = 0;
  constructor(private studentService: StudentService) { }

  ngOnInit(): void {
    this.get();

    this.addORUpdateModal = new window.bootstrap.Modal(
      document.getElementById('addORUpdateModal')
    );

    this.deleteModal = new window.bootstrap.Modal(
      document.getElementById('deleteModal')
    );
  }

  get() {
    this.studentService.get().subscribe({
      next: (data) => {
        this.students = data;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  
  openAddOrUpdateModal(studentId: number) {
    if (studentId === 0) {
      this.addorupdatemodalTitle = 'Add';
      this.studentForm = {
        age: 0,
        gender: 'Male',
        id: 0,
        name: '',
      };
    } else {
      this.addorupdatemodalTitle = 'Update';
      this.studentForm = this.students.filter((s) => s.id === studentId)[0];
    }
    this.addORUpdateModal.show();
  }

  createorUpdateStudent() {
    if (this.studentForm.id == 0) {
      this.studentService.post(this.studentForm).subscribe({
        next: (data) => {
          this.students.unshift(data);
          this.addORUpdateModal.hide();
        },
        error: (error) => {
          console.log(error);
        },
      });
    } else {
      this.studentService.update(this.studentForm).subscribe({
        next: (data) => {
          this.students = this.students.filter((s) => s.id !== data.id);
          this.students.unshift(data);
          this.addORUpdateModal.hide();
        },
        error: (error) => {
          console.log(error);
        },
      });
    }
  }

  openDeleteModal(studentId: number) {
    this.studentIdToDelete = studentId;
    this.deleteModal.show();
  }

  confirmDelete(){
    this.studentService.delete(this.studentIdToDelete)
    .subscribe({
      next:(data) => {
        this.students = this.students.filter(s => s.id !== this.studentIdToDelete);
        this.studentIdToDelete = 0;
        this.deleteModal.hide();
      },
      error:(error) => {
        console.log(error);
      }
    })
  }

}
