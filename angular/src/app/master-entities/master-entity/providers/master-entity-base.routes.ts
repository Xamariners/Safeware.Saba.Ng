import { ABP, eLayoutType } from '@abp/ng.core';

export const MASTER_ENTITY_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/master-entities',
    iconClass: 'fas fa-file-alt',
    name: '::Menu:MasterEntities',
    layout: eLayoutType.application,
    requiredPolicy: 'Ng.MasterEntities',
    breadcrumbText: '::MasterEntities',
  },
];
