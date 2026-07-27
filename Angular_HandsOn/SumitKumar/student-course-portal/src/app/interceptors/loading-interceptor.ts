import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { finalize } from 'rxjs';
import { LoadingService } from '../services/loading';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const loadingService = inject(LoadingService);

  // Set isLoading$ to true before handling the request (Step 91)
  loadingService.show();

  return next(req).pipe(
    // finalize runs whether the Observable completes successfully or errors out
    finalize(() => {
      loadingService.hide();
    }),
  );
};
