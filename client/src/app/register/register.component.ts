import { Component, inject, input, output, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  private toastr = inject(ToastrService);

  // usersFromHomeComponent = input.required<any>;
  // @Input() usersFromHomeComponent2: any

  cancelRegister = output<boolean>(); // child to parent --> @Output() cancelRegister = new EventEmiiter();  //old way
  model: any = {};

  stringTest = input.required<string>

  register() {
    this.accountService.register(this.model).subscribe({
      next: response => {
        console.log(response);
        this.cancel();
        this.toastr.success("User create succesfully");
      },
      error: error => {this.toastr.error(error.error);
      this.toastr.error("Please fill the form")}
    })
  }

  test() {
    console.log(this.stringTest)
    // this.stringTest.emit("hi from thailand");
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
