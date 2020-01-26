
export class BaseClient {
    protected async transformOptions(options: RequestInit): Promise<RequestInit> {
        return Promise.resolve(options);
    }
}