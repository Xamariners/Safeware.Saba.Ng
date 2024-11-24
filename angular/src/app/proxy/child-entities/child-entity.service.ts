import type {
  ChildEntityCreateDto,
  ChildEntityDto,
  ChildEntityUpdateDto,
  ChildEntityWithNavigationPropertiesDto,
  GetChildEntitiesInput,
  GetChildEntityListInput,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type {
  AppFileDescriptorDto,
  DownloadTokenResultDto,
  GetFileInput,
  LookupDto,
  LookupRequestDto,
} from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class ChildEntityService {
  apiName = 'Default';

  create = (input: ChildEntityCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ChildEntityDto>(
      {
        method: 'POST',
        url: '/api/app/child-entities',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/child-entities/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ChildEntityDto>(
      {
        method: 'GET',
        url: `/api/app/child-entities/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getBookLookup = (input: LookupRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>(
      {
        method: 'GET',
        url: '/api/app/child-entities/book-lookup',
        params: {
          filter: input.filter,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/app/child-entities/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/child-entities/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetChildEntitiesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ChildEntityWithNavigationPropertiesDto>>(
      {
        method: 'GET',
        url: '/api/app/child-entities',
        params: {
          masterEntityId: input.masterEntityId,
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          enabled: input.enabled,
          bookId: input.bookId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListByMasterEntityId = (input: GetChildEntityListInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ChildEntityWithNavigationPropertiesDto>>(
      {
        method: 'GET',
        url: '/api/app/child-entities/by-master-entity',
        params: {
          masterEntityId: input.masterEntityId,
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListWithNavigationPropertiesByMasterEntityId = (
    input: GetChildEntityListInput,
    config?: Partial<Rest.Config>,
  ) =>
    this.restService.request<any, PagedResultDto<ChildEntityWithNavigationPropertiesDto>>(
      {
        method: 'GET',
        url: '/api/app/child-entities/detailed/by-master-entity',
        params: {
          masterEntityId: input.masterEntityId,
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getWithNavigationProperties = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ChildEntityWithNavigationPropertiesDto>(
      {
        method: 'GET',
        url: `/api/app/child-entities/with-navigation-properties/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: string, input: ChildEntityUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ChildEntityDto>(
      {
        method: 'PUT',
        url: `/api/app/child-entities/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/app/child-entities/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
