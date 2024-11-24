import { inject, ChangeDetectorRef } from '@angular/core';
import { filter, switchMap } from 'rxjs/operators';
import { ABP, ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import type {
  GetChildEntityListInput,
  ChildEntityWithNavigationPropertiesDto,
} from '../../../proxy/child-entities/models';
import { ChildEntityService } from '../../../proxy/child-entities/child-entity.service';

export abstract class AbstractChildEntityViewService {
  protected readonly cdr = inject(ChangeDetectorRef);
  protected readonly proxyService = inject(ChildEntityService);
  protected readonly confirmationService = inject(ConfirmationService);
  protected readonly list = inject(ListService);

  data: PagedResultDto<ChildEntityWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  delete(record: ChildEntityWithNavigationPropertiesDto) {
    this.confirmationService
      .warn('::DeleteConfirmationMessage', '::AreYouSure', { messageLocalizationParams: [] })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.proxyService.delete(record.childEntity.id)),
      )
      .subscribe(this.list.get);
  }

  hookToQuery(masterEntityId: string) {
    const getData = (query: ABP.PageQueryParams) =>
      this.proxyService.getListWithNavigationPropertiesByMasterEntityId({
        ...(query as GetChildEntityListInput),
        masterEntityId,
      });

    const setData = (list: PagedResultDto<ChildEntityWithNavigationPropertiesDto>) =>
      (this.data = list);

    this.list.hookToQuery(getData).subscribe(list => {
      setData(list);
      this.cdr.markForCheck();
    });
  }
}
