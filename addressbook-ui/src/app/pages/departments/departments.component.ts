import { Component, OnInit } from '@angular/core';
import { DepartmentService, Department } from 'src/app/services/department.service';

declare var bootstrap: any;

@Component({
  selector: 'app-department',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.css']
})
export class DepartmentComponent implements OnInit {

  departments: Department[] = [];

  newDepartmentName: string = '';

  selectedDepartment: Department = { id: 0, name: '' };

  constructor(private departmentService: DepartmentService) { }

  ngOnInit(): void {
    this.loadDepartments();
  }

  loadDepartments() {
    this.departmentService.getAllDepartments().subscribe({
      next: (res) => this.departments = res,
      error: (err) => console.error(err)
    });
  }

  addDepartment() {
    if (!this.newDepartmentName.trim()) {
      alert('Department name is required!');
      return;
    }

    this.departmentService.addDepartment({ name: this.newDepartmentName })
      .subscribe({
        next: () => {
          this.newDepartmentName = '';
          this.loadDepartments();
        },
        error: (err) => console.error(err)
      });
  }

  openEdit(dept: Department) {
    this.selectedDepartment = { ...dept };
    const modal = new bootstrap.Modal(document.getElementById('editModal'));
    modal.show();
  }

  updateDepartment() {
    if (!this.selectedDepartment.name.trim()) {
      alert('Department name is required!');
      return;
    }

    this.departmentService.updateDepartment(this.selectedDepartment.id, {
      name: this.selectedDepartment.name
    }).subscribe({
      next: () => {
        this.loadDepartments();
        this.closeModal();
      },
      error: (err) => console.error(err)
    });
  }

  deleteDepartment(id: number) {
    if (confirm('Are you sure you want to delete this department?')) {
      this.departmentService.deleteDepartment(id).subscribe({
        next: () => this.loadDepartments(),
        error: (err) => console.error(err)
      });
    }
  }

  closeModal() {
    const modalElement = document.getElementById('editModal');
    const modal = bootstrap.Modal.getInstance(modalElement);
    modal.hide();
  }
}