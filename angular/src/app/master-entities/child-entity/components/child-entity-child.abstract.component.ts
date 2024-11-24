import { Directive, OnInit, inject, Input } from '@angular/core';
import { ListService, TrackByService } from '@abp/ng.core';

import type { ChildEntityWithNavigationPropertiesDto } from '../../../proxy/child-entities/models';
import { ChildEntityViewService } from '../services/child-entity-child.service';
import { ChildEntityDetailViewService } from '../services/child-entity-child-detail.service';

@Directive({ standalone: true })
export abstract class AbstractChildEntityComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(ChildEntityViewService);
  public readonly serviceDetail = inject(ChildEntityDetailViewService);

  @Input() title = '::ChildEntities';

  @Input() masterEntityId: string;

  ngOnInit() {
    this.serviceDetail.masterEntityId = this.masterEntityId;
    this.service.hookToQuery(this.masterEntityId);
  }

  create() {
    this.serviceDetail.selected = undefined;
    this.serviceDetail.showForm();
  }

  update(record: ChildEntityWithNavigationPropertiesDto) {
    this.serviceDetail.update(record);
  }

  delete(record: ChildEntityWithNavigationPropertiesDto) {
    this.service.delete(record);
  }
}
