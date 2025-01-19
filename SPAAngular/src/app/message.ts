import { Data } from "@angular/router";

export class Message {
  constructor(
    public id?: string,
    public UserName?: string,
    public StartTime?: Date,
    public EndTime?: Date,
    public VersionPA?: string) { }
}

