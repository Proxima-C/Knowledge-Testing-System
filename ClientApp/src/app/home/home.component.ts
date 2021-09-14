import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Test } from '../interfaces/test.model';
import { TestService } from '../services/test/test.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  tests: Test[] = [];

  constructor(private router: Router, private testService: TestService) { }

  ngOnInit(): void {
    this.refreshTests();
  }

  refreshTests() {
    this.testService.getAll().subscribe((data: Test[]) => {
      this.tests = data;
    });
  }
}
