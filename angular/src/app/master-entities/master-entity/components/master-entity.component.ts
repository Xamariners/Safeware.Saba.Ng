import { ChangeDetectionStrategy, Component } from '@angular/core';
import {
  NgbDateAdapter,
  NgbTimeAdapter,
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ListService, CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { PageModule } from '@abp/ng.components/page';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

import { MasterEntityViewService } from '../services/master-entity.service';
import { MasterEntityDetailViewService } from '../services/master-entity-detail.service';
import { MasterEntityDetailModalComponent } from './master-entity-detail.component';
import {
  AbstractMasterEntityComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './master-entity.abstract.component';

@Component({
  selector: 'app-master-entity',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
  imports: [
    ...ChildTabDependencies,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    NgbDropdownModule,

    NgxValidateCoreModule,

    PageModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    MasterEntityDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    MasterEntityViewService,
    MasterEntityDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './master-entity.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class MasterEntityComponent extends AbstractMasterEntityComponent {}
