import { Component, OnInit } from '@angular/core';
import { JobService } from '../../services/job.service';
import { Job } from '../../models/job.model';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent implements OnInit {
  jobs: Job[] = [];
  job: Job = { id: 0, title: '' }; 
  selectedJob: Job | null = null;

  constructor(private jobService: JobService) { }

  ngOnInit(): void {
    this.loadJobs();
  }

  loadJobs() {
    this.jobService.getAllJobs().subscribe(res => this.jobs = res);
  }

  addJob() {
    if (!this.job.title) return;

    this.jobService.addJob(this.job).subscribe({
      next: res => {
        console.log('Job added', res);
        this.job.title = '';
        this.loadJobs(); 
      },
      error: err => console.error('Error adding job', err)
    });
  }

  selectJob(job: Job) {
    this.selectedJob = { ...job }; 
  }

  updateJob() {
    if (!this.selectedJob) return;

    this.jobService.updateJob(this.selectedJob.id, this.selectedJob).subscribe({
      next: () => {
        console.log('Job updated');
        this.selectedJob = null;
        this.loadJobs();
      },
      error: err => console.error('Error updating job', err)
    });
  }

  deleteJob(id: number) {
    this.jobService.deleteJob(id).subscribe({
      next: () => {
        console.log('Job deleted');
        this.loadJobs();
      },
      error: err => console.error('Error deleting job', err)
    });
  }
}