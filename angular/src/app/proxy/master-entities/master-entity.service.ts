import type {
  GetMasterEntitiesInput,
  MasterEntityCreateDto,
  MasterEntityDto,
  MasterEntityExcelDownloadDto,
  MasterEntityUpdateDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AppFileDescriptorDto, DownloadTokenResultDto, GetFileInput } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class MasterEntityService {
  apiName = 'Default';

  create = (input: MasterEntityCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, MasterEntityDto>(
      {
        method: 'POST',
        url: '/api/app/master-entities',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/master-entities/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetMasterEntitiesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/master-entities/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          costMin: input.costMin,
          costMax: input.costMax,
          address: input.address,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (masterEntityIds: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/master-entities',
        params: { masterEntityIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, MasterEntityDto>(
      {
        method: 'GET',
        url: `/api/app/master-entities/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/app/master-entities/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/master-entities/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetMasterEntitiesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<MasterEntityDto>>(
      {
        method: 'GET',
        url: '/api/app/master-entities',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          costMin: input.costMin,
          costMax: input.costMax,
          address: input.address,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (input: MasterEntityExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/master-entities/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          name: input.name,
          costMin: input.costMin,
          costMax: input.costMax,
          address: input.address,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: string, input: MasterEntityUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, MasterEntityDto>(
      {
        method: 'PUT',
        url: `/api/app/master-entities/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/app/master-entities/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
