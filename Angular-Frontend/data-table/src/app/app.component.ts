import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <!--The content below is only a placeholder and can be replaced.-->
    <div style="text-align:center" class="content">
      <h1>
        Welcome to Niko's {{title}}.
      </h1>
      <span style="display: block">{{ title }} app is running.</span>
    </div>
    <h2>Here are some links to help you start: </h2>
    <ul>
      <li>
        <h2><a routerLink="/users">Go To Users</a></h2>
    </ul>
    <router-outlet></router-outlet>
  `,
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Data Table';
}
