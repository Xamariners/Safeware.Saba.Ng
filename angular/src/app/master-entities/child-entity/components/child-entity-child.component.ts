import { ChangeDetectionStrategy, Component } from '@angular/core';
import {
  NgbDateAdapter,
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ListService, CoreModule } from '@abp/ng.core';
import { PageModule } from '@abp/ng.components/page';
import { ThemeSharedModule, DateAdapter } from '@abp/ng.theme.shared';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

import { ChildEntityViewService } from '../services/child-entity-child.service';
import { ChildEntityDetailViewService } from '../services/child-entity-child-detail.service';
import { ChildEntityDetailModalComponent } from './child-entity-child-detail.component';
import { AbstractChildEntityComponent } from './child-entity-child.abstract.component';

@Component({
  standalone: true,
  selector: 'app-child-entity',
  imports: [
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,
    NgxValidateCoreModule,
    CoreModule,
    PageModule,
    ThemeSharedModule,
    ChildEntityDetailModalComponent,
    CommercialUiModule,
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    { provide: NgbDateAdapter, useClass: DateAdapter },
    ListService,
    ChildEntityViewService,
    ChildEntityDetailViewService,
  ],
  templateUrl: './child-entity-child.component.html',
})
export class ChildEntityComponent extends AbstractChildEntityComponent {}
