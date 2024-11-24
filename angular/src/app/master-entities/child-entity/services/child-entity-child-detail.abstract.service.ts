import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { ChildEntityWithNavigationPropertiesDto } from '../../../proxy/child-entities/models';
import { ChildEntityService } from '../../../proxy/child-entities/child-entity.service';

export abstract class AbstractChildEntityDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(ChildEntityService);
  public readonly list = inject(ListService);

  public readonly getBookLookup = this.proxyService.getBookLookup;

  masterEntityId: string;

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    if (this.selected) {
      return this.proxyService.update(this.selected.id, this.form.value);
    }
    return this.proxyService.create(this.form.value);
  }

  buildForm() {
    const { bookId, name, enabled } = this.selected || {};

    this.form = this.fb.group({
      masterEntityId: [this.masterEntityId],
      bookId: [bookId ?? null, []],
      name: [name ?? null, []],
      enabled: [enabled ?? false, []],
    });
  }

  showForm() {
    this.buildForm();
    this.isVisible = true;
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: ChildEntityWithNavigationPropertiesDto) {
    this.selected = record.childEntity;
    this.showForm();
  }

  hideForm() {
    this.isVisible = false;
  }

  submitForm() {
    if (this.form.invalid) return;

    this.isBusy = true;

    const request = this.createRequest().pipe(
      finalize(() => (this.isBusy = false)),
      tap(() => this.hideForm()),
    );

    request.subscribe(this.list.get);
  }

  changeVisible(isVisible: boolean) {
    this.isVisible = isVisible;
  }
}
