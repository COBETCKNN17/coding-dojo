import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { EditComponent } from './edit/edit.component';
import { CreateComponent } from './create/create.component';
import { FileNotFoundComponent } from './file-not-found/file-not-found.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'create', component: CreateComponent },
    { path: 'list', component: ListComponent, children: [
            { path: 'edit/:id', component: EditComponent },
        ]
    },
    { path: '**', component: FileNotFoundComponent },
];


@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingcomponent = [ListComponent, EditComponent, CreateComponent, FileNotFoundComponent, HomeComponent]