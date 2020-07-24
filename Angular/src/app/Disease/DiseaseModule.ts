import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { CommonModule } from '@angular/common';
import { MyJwtInterceptor } from '../Utilities/Token.Interceptor';
import { DiseaseComponent } from './DiseaseComponent';
import { Droutes } from '../Routing/DiseaseRouting';
@NgModule({
  declarations: [
    DiseaseComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(Droutes),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MyJwtInterceptor,
      multi: true
    }
  ],
  bootstrap: [DiseaseComponent]
})
export class DiseaseModule {
}
