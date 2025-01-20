import { Data } from "@angular/router";

//export class Message {
//  public Id?: string;
//  public UserName?: string;
//  public StartTime?: Date;
//  public EndTime?: Date;
//  public VersionPA?: string;

//  constructor(
//    id?: string,
//    userName?: string,
//    startTime?: Date,
//    endTime?: Date,
//    versionPA?: string)
//  {
//    this.Id = id;
//    this.UserName = userName;
//    this.StartTime = startTime;
//    this.EndTime = endTime;
//    this.VersionPA = versionPA;
//  }
//}

export interface Message {
  id: string;
  userName: string;
  startTime: Date;
  endTime: Date;
  versionPA: string;
}
