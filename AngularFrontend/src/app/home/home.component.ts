import { Component } from '@angular/core';

import { AccountService, AlertService } from '@app/_services';

import { HttpClient } from '@angular/common/http';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { environment } from '@environments/environment';
const baseUrl = `${environment.apiUrl}`;


@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    account = this.accountService.accountValue;
    totalAngularPackages:string;
    form: FormGroup;
    loading = false;
    submitted = false;

    constructor(private accountService: AccountService,
       private http: HttpClient,
       private formBuilder: FormBuilder,
       private alertService: AlertService) { }

    ngOnInit() {
      this.form = this.formBuilder.group({
          temp: ['', [Validators.required]],
      });
    }

  // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit(){
        //this.http.get<any>('https://api.npms.io/v2/search?q=scope:angular').subscribe(data => {
        //this.totalAngularPackages = data.total;
        //})
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.loading = true;
        const headers = { Authorization: `Bearer ${this.account.jwtToken}` };
        this.http.post<any>(`${baseUrl}/matlab/run-script-url-input/` + this.f.temp.value, {}, { headers }).subscribe(data => {
        this.totalAngularPackages = data.result;
        })
        this.loading = false;
        return this.totalAngularPackages;
      }
}