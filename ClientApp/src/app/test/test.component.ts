import { Component, OnInit } from '@angular/core';

import { TestService } from '../services/test/test.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  constructor(private testService: TestService) { }

  ngOnInit(): void {
  }

}
