import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { MASTER_ENTITY_BASE_ROUTES } from './master-entity-base.routes';

export const MASTER_ENTITIES_MASTER_ENTITY_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...MASTER_ENTITY_BASE_ROUTES];
    routesService.add(routes);
  };
}
