import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface ChildEntityCreateDto {
  name?: string;
  enabled: boolean;
  bookId?: string;
}

export interface ChildEntityDto extends FullAuditedEntityDto<string> {
  name?: string;
  enabled: boolean;
  bookId?: string;
}

export interface ChildEntityUpdateDto {
  name?: string;
  enabled: boolean;
  bookId?: string;
}

export interface ChildEntityWithNavigationPropertiesDto {
  childEntity: ChildEntityDto;
  book: BookDto;
}

export interface GetChildEntitiesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  enabled?: boolean;
  bookId?: string;
  masterEntityId: string;
}

export interface GetChildEntityListInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  masterEntityId: string;
}
