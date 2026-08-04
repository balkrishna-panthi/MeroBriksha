import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const cloned = req.clone({
    setHeaders:{
      Authorization : `Basic ` + btoa('admin:1234')
    }
  })
  return next(cloned);
};
