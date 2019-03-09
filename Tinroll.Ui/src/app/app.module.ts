import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { UserComponent } from './user/user.component';
import { UserAddComponent } from './user-add/user-add.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserEditComponent } from './user-edit/user-edit.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';

const appRoutes: Routes = [
  {
    path: 'users',
    component: UserComponent,
    data: { title: 'User List' }
  },
  {
    path: 'user-details/:id',
    component: UserDetailComponent,
    data: { title: 'User Details' }
  },
  {
    path: 'user-add',
    component: UserAddComponent,
    data: { title: 'User Add' }
  },
  {
    path: 'user-edit/:id',
    component: UserEditComponent,
    data: { title: 'User Edit' }
  },
  { path: '',
    redirectTo: '/users',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    UserAddComponent,
    UserDetailComponent,
    UserEditComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
