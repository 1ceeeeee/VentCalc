import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'spinner-form',
  templateUrl: './spinner-form.component.html'  
})
export class SpinnerFormComponent implements OnInit {

  constructor() { }

  @Input()
  public isRunning: boolean = false;

  ngOnInit() {
  }

}
