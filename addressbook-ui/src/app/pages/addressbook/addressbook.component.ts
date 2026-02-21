import { Component , OnInit} from '@angular/core';
import { AddressbookService } from '../../services/addressbook.service';
import { HttpClient } from '@angular/common/http';

declare var bootstrap: any;

@Component({
  selector: 'app-addressbook',
  templateUrl: './addressbook.component.html',
  styleUrls: ['./addressbook.component.css']
})
export class AddressbookComponent implements OnInit{

  addressList: any[] = [];
  addressListOriginal: any[] = [];
  selectedEntry: any = {};
  searchModel: any = {};

  jobs: any[] = [];
  departments: any[] = [];

  newEntry: any = {
    fullName: '',
    mobileNumber: '',
    jobId: null,
    departmentId: null,
    dateOfBirth: '',
    email: '',
    address: '',
    photoPath: ''
  };

  constructor(private service: AddressbookService, private http: HttpClient) {}

  ngOnInit(): void {
    this.loadData();
    this.loadJobs();
    this.loadDepartments();
  }

  loadJobs() {
    this.http.get('https://localhost:7215/api/Job').subscribe((res: any) => {
      this.jobs = res;
    });
  }

  loadDepartments() {
    this.http.get('https://localhost:7215/api/Department').subscribe((res: any) => {
      this.departments = res;
    });
  }

  loadData() {
    this.service.getAllAddressbook().subscribe(res => {
      this.addressList = res;
      this.addressListOriginal = [...res];
    });
  }

  search() {
    this.addressList = this.addressListOriginal.filter(entry => {
      return (!this.searchModel.fullName || (entry.fullName && entry.fullName.toLowerCase().includes(this.searchModel.fullName.toLowerCase()))) &&
             (!this.searchModel.jobTitle || (entry.jobTitle && entry.jobTitle.toLowerCase().includes(this.searchModel.jobTitle.toLowerCase()))) &&
             (!this.searchModel.department || (entry.department && entry.department.toLowerCase().includes(this.searchModel.department.toLowerCase())));
  })};


  openEdit(entry: any) {
    this.selectedEntry = { ...entry };
    const modal = new bootstrap.Modal(document.getElementById('editEntryModal'));
    modal.show();
  }

  saveEdit() {
    if (!this.selectedEntry.fullName || !this.selectedEntry.email) {
      alert('Full Name and Email are required!');
      return;
    }

    const currentUserId = localStorage.getItem('currentUserId'); 
    if (!currentUserId) {
      alert('Please login first!');
      return;
    }

    const today = new Date();
    const birthDate = new Date(this.selectedEntry.dateOfBirth);
    let age = today.getFullYear() - birthDate.getFullYear();
    const monthDiff = today.getMonth() - birthDate.getMonth();
    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }
    if (age < 10) {
      alert('Age must be at least 10 years old!');
      return;
    }

    const bodyToSend = {
      id: this.selectedEntry.id,
      userId: Number(currentUserId),
      jobId: this.selectedEntry.jobId,
      departmentId: this.selectedEntry.departmentId,
      fullName: this.selectedEntry.fullName,
      mobileNumber: this.selectedEntry.mobileNumber,
      dateOfBirth: this.selectedEntry.dateOfBirth,
      email: this.selectedEntry.email,
      address: this.selectedEntry.address,
      photoPath: this.selectedEntry.photoPath
    };

    console.log('bodyToSend for edit:', bodyToSend);

    this.http.put(`https://localhost:7215/api/AddressBook/${this.selectedEntry.id}`, bodyToSend, {
      headers: { 'Content-Type': 'application/json' }
    }).subscribe({
      next: (res) => {
        console.log('Entry updated', res);
        this.loadData();
        this.closeModal('editEntryModal');
      },
      error: (err) => {
        console.error('Error updating entry:', err);
        alert('There was an error updating the entry!');
      }
    });
  }

  deleteEntry(id: number) {
    if (confirm('Are you sure you want to delete this entry?')) {
        this.service.deleteAddressbook(id).subscribe(() => {
        this.loadData();
      });
    }
  }

  closeModal(modalId: string = 'editEntryModal') {
    const modalElement = document.getElementById(modalId);
    const modal = bootstrap.Modal.getInstance(modalElement);
    modal.hide();
  }


  openAddModal() {
    this.newEntry = {
      fullName: '',
      mobileNumber: '',
      jobId: null,
      departmentId: null,
      dateOfBirth: '',
      email: '',
      address: '',
      photoPath: ''
    };
    const modal = new bootstrap.Modal(document.getElementById('addEntryModal'));
    modal.show();
  }

  saveNewEntry() {
    if (!this.newEntry.fullName || !this.newEntry.email) {
      alert('Full Name and Email are required!');
      return;
    }

    const currentUserId = localStorage.getItem('currentUserId'); 
    if (!currentUserId) {
      alert('Please login first!');
      return;
    }

    const today = new Date();
    const birthDate = new Date(this.newEntry.dateOfBirth);
    let age = today.getFullYear() - birthDate.getFullYear();
    const monthDiff = today.getMonth() - birthDate.getMonth();
    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }
    if (age < 10) {
      alert('Age must be at least 10 years old!');
      return;
    }

    const bodyToSend = {
      userId: Number(currentUserId),
      jobId: this.newEntry.jobId,
      departmentId: this.newEntry.departmentId,
      fullName: this.newEntry.fullName,
      mobileNumber: this.newEntry.mobileNumber,
      dateOfBirth: this.newEntry.dateOfBirth,
      email: this.newEntry.email,
      address: this.newEntry.address,
      photoPath: this.newEntry.photoPath
    };

    console.log('bodyToSend:', bodyToSend);

    this.http.post('https://localhost:7215/api/AddressBook', bodyToSend, {
      headers: { 'Content-Type': 'application/json' }
    }).subscribe({
      next: (res) => {
        console.log('Entry added', res);
        this.loadData(); 
        this.closeModal('addEntryModal');
      },
      error: (err) => {
        console.error('Error adding entry:', err);
        alert('There was an error saving the entry!');
      }
    });
  }


  exportToExcel() {
    if (!this.addressList || this.addressList.length === 0) return;

    const headers = ['Full Name', 'Job Title', 'Department', 'Mobile', 'Date of Birth', 'Email'];
    const csvRows = this.addressList.map(entry => {
      const fullName = entry.fullName ?? '';
      const jobTitle = entry.jobTitle ?? '';
      const department = entry.department ?? '';
      const mobile = entry.mobileNumber ?? '';
      const dob = entry.dateOfBirth ?? '';
      const email = entry.email ?? '';

      return [fullName, jobTitle, department, mobile, dob, email].join(',');
    });

    csvRows.unshift(headers.join(','));

    const blob = new Blob([csvRows.join('\n')], { type: 'text/csv' });
    const a = document.createElement('a');
    a.href = URL.createObjectURL(blob);
    a.download = 'addressbook.csv';
    a.click();
  }
}