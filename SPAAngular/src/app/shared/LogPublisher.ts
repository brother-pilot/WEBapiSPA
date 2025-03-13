import { Observable } from 'rxjs';
import { LogMessage } from '../core/services/LogMessage';


 export  abstract class LogPublisher {
   location: string = "";
   //This property is used to set the key for local storage and the URL for the Web API
   abstract log(record: LogMessage):
    Observable<boolean>
   abstract clear(): Observable<boolean>;
   //method removes all log entries from the data store
}


