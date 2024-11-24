import { Directive, OnInit, inject, ViewChild } from '@angular/core';

import {
  NgbNav,
  NgbNavItem,
  NgbNavLink,
  NgbNavContent,
  NgbNavOutlet,
} from '@ng-bootstrap/ng-bootstrap';
import { ListService, TrackByService } from '@abp/ng.core';

import type { MasterEntityDto } from '../../../proxy/master-entities/models';
import { MasterEntityViewService } from '../services/master-entity.service';
import { MasterEntityDetailViewService } from '../services/master-entity-detail.service';
import { ChildEntityComponent } from '../../child-entity/components/child-entity-child.component';

export const ChildTabDependencies = [NgbNav, NgbNavItem, NgbNavLink, NgbNavContent, NgbNavOutlet];

export const ChildComponentDependencies = [ChildEntityComponent];

@Directive({ standalone: true })
export abstract class AbstractMasterEntityComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(MasterEntityViewService);
  public readonly serviceDetail = inject(MasterEntityDetailViewService);
  protected title = '::MasterEntities';

  @ViewChild('masterEntityTable') table: any;

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

  toggleExpandRow(row) {
    this.table.rowDetail.toggleExpandRow(row);
  }
}
