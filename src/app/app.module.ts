import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { ProgressBarComponent } from '../components/progress-bar/progress-bar';
import { Code0Page } from '../pages/code0/code0'
import { Code1Page } from '../pages/code1/code1';
import { Code2Page } from '../pages/code2/code2';
import { Code3Page } from '../pages/code3/code3';
import { Code4Page } from '../pages/code4/code4';
import { Code5Page } from '../pages/code5/code5';
import { Code6Page } from '../pages/code6/code6';
import { Code7Page } from '../pages/code7/code7';
import { Code8Page } from '../pages/code8/code8';
import { Code9Page } from '../pages/code9/code9';
import { Code10Page } from '../pages/code10/code10';
import { Code11Page } from '../pages/code11/code11';
import { Code12Page } from '../pages/code12/code12';
@NgModule({
  declarations: [
    MyApp,
    HomePage,
    ProgressBarComponent,
    Code0Page,
    Code1Page,
    Code2Page,
    Code3Page,
    Code4Page,
    Code5Page,
    Code6Page,
    Code7Page,
    Code8Page,
    Code9Page,
    Code10Page,
    Code11Page,
    Code12Page

  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp)
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,    
    Code0Page,
    Code1Page,
    Code2Page,
    Code3Page,
    Code4Page,
    Code5Page,
    Code6Page,
    Code7Page,
    Code8Page,
    Code9Page,
    Code10Page,
    Code11Page,
    Code12Page
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler}
  ]
})
export class AppModule {}
