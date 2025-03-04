import { IConstruction } from '../interfaces/construction.interface';
import { IConstructionRequest } from '../interfaces/construction-request.interface';

export class ConstructionManager {
  private pendingRequests: Map<IConstruction, IConstructionRequest> = new Map();
  
  submitRequest(request: IConstructionRequest): void {
    this.pendingRequests.set(request.subject, request);
  }
  
  executeRequest(request: IConstructionRequest): void {
    request.execute();
  }
  
  executePendingRequests(): void {
    const requests = Array.from(this.pendingRequests.values());
    this.pendingRequests.clear();
    
    for (const request of requests) {
      this.executeRequest(request);
    }
  }
  
  clearRequests(): void {
    this.pendingRequests.clear();
  }
}
