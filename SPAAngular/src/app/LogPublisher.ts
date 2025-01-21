import { Observable } from 'rxjs';
import 'rxjs/add/observable/of';
import { LogEntry } from './log.service';

 export  abstract class LogPublisher {
  location: string="";
  abstract log(record: LogEntry):
    Observable<boolean>
  abstract clear(): Observable<boolean>;
}


