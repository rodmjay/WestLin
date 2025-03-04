export class EventEmitter<T> {
  private listeners: ((data: T) => void)[] = [];
  
  subscribe(listener: (data: T) => void): { unsubscribe: () => void } {
    this.listeners.push(listener);
    
    return {
      unsubscribe: () => {
        const index = this.listeners.indexOf(listener);
        if (index !== -1) {
          this.listeners.splice(index, 1);
        }
      }
    };
  }
  
  emit(data?: any): void {
    this.listeners.forEach(listener => listener(data));
  }
}
