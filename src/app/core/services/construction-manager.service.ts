import { Injectable } from '@angular/core';
import { Construction } from '../interfaces/construction.interface';

export interface ConstructionRequest {
  subject: Construction;
  execute(): void;
}

@Injectable({
  providedIn: 'root'
})
export class ConstructionManagerService {
  private pendingRequests: Map<Construction, ConstructionRequest> = new Map();
  
  submitRequest(request: ConstructionRequest): void {
    this.pendingRequests.set(request.subject, request);
  }
  
  executeRequest(request: ConstructionRequest): void {
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
