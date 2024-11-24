import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { MasterEntityDto } from '../../../proxy/master-entities/models';
import { MasterEntityViewService } from '../services/master-entity.service';
import { MasterEntityDetailViewService } from '../services/master-entity-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractMasterEntityComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(MasterEntityViewService);
  public readonly serviceDetail = inject(MasterEntityDetailViewService);
  protected title = '::MasterEntities';

  ngOnInit() {
    this.service.hookToQuery();
  }

  clearFilters() {
    this.service.clearFilters();
  }

  showForm() {
    this.serviceDetail.showForm();
  }

  create() {
    this.serviceDetail.selected = undefined;
    this.serviceDetail.showForm();
  }

  update(record: MasterEntityDto) {
    this.serviceDetail.update(record);
  }

  delete(record: MasterEntityDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }
}
