import { Component, Input, Output, EventEmitter } from '@angular/core';

//Responsible for displaying a confirmation dialog with the options yes and no, and the message specified in the property message
//It will call the onConfirm event when there is a Ok click. Otherwise, it will close the modal
@Component({
  selector: 'confimation-dialog',
  templateUrl: './dialog.component.html',
})
export class ConfirmationDialog {
  isOpen: boolean = false;
  @Output() onConfirm: EventEmitter<any> = new EventEmitter();
  @Input() message: string;

  public open() { this.isOpen = true; }
  close() { this.isOpen = false; }
  confirm() {
    this.onConfirm.emit();
    this.close();
  }
}
