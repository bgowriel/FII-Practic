export interface PagedResponse<T> {
    data: T;
    errors: string[];
    firstPage: URL;
    lastPage: URL;
    previousPage: URL;
    nextPage: URL;
    message: string;
    pageNumber: number;
    pageSize: number;
    totalRecords: number;
    totalPages: number;
    statusCode: number;
}