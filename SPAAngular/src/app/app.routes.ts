import { Routes } from "@angular/router";
import { DeviceListComponent } from "./device-list/device-list.component";
import { MessageListComponent } from "./message-list/message-list.component";
import { DeleteMessageComponent } from "./delete-message/delete-message.component";


export const routes: Routes = [
  {
    path: "",
    redirectTo: "devices",
    pathMatch: "full"
  },
  { path: "devices", component: DeviceListComponent },
  { path: "messages/:deviceId", component: MessageListComponent },
  { path: "delete", component: DeleteMessageComponent }
  //{ path: "products/edit/:id", component: ProductCreateEditComponent }
];
