import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetMasterEntitiesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  costMin?: number;
  costMax?: number;
  address?: string;
}

export interface MasterEntityCreateDto {
  name?: string;
  cost: number;
  address: string;
}

export interface MasterEntityDto extends FullAuditedEntityDto<string> {
  name?: string;
  cost: number;
  address: string;
  concurrencyStamp?: string;
}

export interface MasterEntityExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  costMin?: number;
  costMax?: number;
  address?: string;
}

export interface MasterEntityUpdateDto {
  name?: string;
  cost: number;
  address: string;
  concurrencyStamp?: string;
}
