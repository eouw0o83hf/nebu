/**
 * Generated by orval v6.24.0 🍺
 * Do not edit manually.
 * Nebu.Api
 * OpenAPI spec version: 1.0
 */
import {
  useMutation,
  useQuery
} from '@tanstack/react-query'
import type {
  MutationFunction,
  QueryFunction,
  QueryKey,
  UseMutationOptions,
  UseQueryOptions,
  UseQueryResult
} from '@tanstack/react-query'
import * as axios from 'axios';
import type {
  AxiosError,
  AxiosRequestConfig,
  AxiosResponse
} from 'axios'
import type {
  BlobReadModel,
  PostApiBucketsBucketIdBlobsBody
} from '.././model'



export const getApiBucketsBucketIdBlobs = (
    bucketId: string, options?: AxiosRequestConfig
 ): Promise<AxiosResponse<BlobReadModel[]>> => {
    
    return axios.default.get(
      `/api/buckets/${bucketId}/Blobs`,options
    );
  }


export const getGetApiBucketsBucketIdBlobsQueryKey = (bucketId: string,) => {
    return [`/api/buckets/${bucketId}/Blobs`] as const;
    }

    
export const getGetApiBucketsBucketIdBlobsQueryOptions = <TData = Awaited<ReturnType<typeof getApiBucketsBucketIdBlobs>>, TError = AxiosError<unknown>>(bucketId: string, options?: { query?:UseQueryOptions<Awaited<ReturnType<typeof getApiBucketsBucketIdBlobs>>, TError, TData>, axios?: AxiosRequestConfig}
) => {

const {query: queryOptions, axios: axiosOptions} = options ?? {};

  const queryKey =  queryOptions?.queryKey ?? getGetApiBucketsBucketIdBlobsQueryKey(bucketId);

  

    const queryFn: QueryFunction<Awaited<ReturnType<typeof getApiBucketsBucketIdBlobs>>> = ({ signal }) => getApiBucketsBucketIdBlobs(bucketId, { signal, ...axiosOptions });

      

      

   return  { queryKey, queryFn, enabled: !!(bucketId), ...queryOptions} as UseQueryOptions<Awaited<ReturnType<typeof getApiBucketsBucketIdBlobs>>, TError, TData> & { queryKey: QueryKey }
}

export type GetApiBucketsBucketIdBlobsQueryResult = NonNullable<Awaited<ReturnType<typeof getApiBucketsBucketIdBlobs>>>
export type GetApiBucketsBucketIdBlobsQueryError = AxiosError<unknown>

export const useGetApiBucketsBucketIdBlobs = <TData = Awaited<ReturnType<typeof getApiBucketsBucketIdBlobs>>, TError = AxiosError<unknown>>(
 bucketId: string, options?: { query?:UseQueryOptions<Awaited<ReturnType<typeof getApiBucketsBucketIdBlobs>>, TError, TData>, axios?: AxiosRequestConfig}

  ):  UseQueryResult<TData, TError> & { queryKey: QueryKey } => {

  const queryOptions = getGetApiBucketsBucketIdBlobsQueryOptions(bucketId,options)

  const query = useQuery(queryOptions) as  UseQueryResult<TData, TError> & { queryKey: QueryKey };

  query.queryKey = queryOptions.queryKey ;

  return query;
}



export const postApiBucketsBucketIdBlobs = (
    bucketId: string,
    postApiBucketsBucketIdBlobsBody: PostApiBucketsBucketIdBlobsBody, options?: AxiosRequestConfig
 ): Promise<AxiosResponse<BlobReadModel>> => {const formData = new FormData();
formData.append('File', postApiBucketsBucketIdBlobsBody.File)

    
    return axios.default.post(
      `/api/buckets/${bucketId}/Blobs`,
      formData,options
    );
  }



export const getPostApiBucketsBucketIdBlobsMutationOptions = <TError = AxiosError<unknown>,
    TContext = unknown>(options?: { mutation?:UseMutationOptions<Awaited<ReturnType<typeof postApiBucketsBucketIdBlobs>>, TError,{bucketId: string;data: PostApiBucketsBucketIdBlobsBody}, TContext>, axios?: AxiosRequestConfig}
): UseMutationOptions<Awaited<ReturnType<typeof postApiBucketsBucketIdBlobs>>, TError,{bucketId: string;data: PostApiBucketsBucketIdBlobsBody}, TContext> => {
 const {mutation: mutationOptions, axios: axiosOptions} = options ?? {};

      


      const mutationFn: MutationFunction<Awaited<ReturnType<typeof postApiBucketsBucketIdBlobs>>, {bucketId: string;data: PostApiBucketsBucketIdBlobsBody}> = (props) => {
          const {bucketId,data} = props ?? {};

          return  postApiBucketsBucketIdBlobs(bucketId,data,axiosOptions)
        }

        


   return  { mutationFn, ...mutationOptions }}

    export type PostApiBucketsBucketIdBlobsMutationResult = NonNullable<Awaited<ReturnType<typeof postApiBucketsBucketIdBlobs>>>
    export type PostApiBucketsBucketIdBlobsMutationBody = PostApiBucketsBucketIdBlobsBody
    export type PostApiBucketsBucketIdBlobsMutationError = AxiosError<unknown>

    export const usePostApiBucketsBucketIdBlobs = <TError = AxiosError<unknown>,
    TContext = unknown>(options?: { mutation?:UseMutationOptions<Awaited<ReturnType<typeof postApiBucketsBucketIdBlobs>>, TError,{bucketId: string;data: PostApiBucketsBucketIdBlobsBody}, TContext>, axios?: AxiosRequestConfig}
) => {

      const mutationOptions = getPostApiBucketsBucketIdBlobsMutationOptions(options);

      return useMutation(mutationOptions);
    }
    export const getApiBucketsBucketIdBlobsBlobIdFile = (
    bucketId: string,
    blobId: string, options?: AxiosRequestConfig
 ): Promise<AxiosResponse<void>> => {
    
    return axios.default.get(
      `/api/buckets/${bucketId}/Blobs/${blobId}/file`,options
    );
  }


export const getGetApiBucketsBucketIdBlobsBlobIdFileQueryKey = (bucketId: string,
    blobId: string,) => {
    return [`/api/buckets/${bucketId}/Blobs/${blobId}/file`] as const;
    }

    
export const getGetApiBucketsBucketIdBlobsBlobIdFileQueryOptions = <TData = Awaited<ReturnType<typeof getApiBucketsBucketIdBlobsBlobIdFile>>, TError = AxiosError<unknown>>(bucketId: string,
    blobId: string, options?: { query?:UseQueryOptions<Awaited<ReturnType<typeof getApiBucketsBucketIdBlobsBlobIdFile>>, TError, TData>, axios?: AxiosRequestConfig}
) => {

const {query: queryOptions, axios: axiosOptions} = options ?? {};

  const queryKey =  queryOptions?.queryKey ?? getGetApiBucketsBucketIdBlobsBlobIdFileQueryKey(bucketId,blobId);

  

    const queryFn: QueryFunction<Awaited<ReturnType<typeof getApiBucketsBucketIdBlobsBlobIdFile>>> = ({ signal }) => getApiBucketsBucketIdBlobsBlobIdFile(bucketId,blobId, { signal, ...axiosOptions });

      

      

   return  { queryKey, queryFn, enabled: !!(bucketId && blobId), ...queryOptions} as UseQueryOptions<Awaited<ReturnType<typeof getApiBucketsBucketIdBlobsBlobIdFile>>, TError, TData> & { queryKey: QueryKey }
}

export type GetApiBucketsBucketIdBlobsBlobIdFileQueryResult = NonNullable<Awaited<ReturnType<typeof getApiBucketsBucketIdBlobsBlobIdFile>>>
export type GetApiBucketsBucketIdBlobsBlobIdFileQueryError = AxiosError<unknown>

export const useGetApiBucketsBucketIdBlobsBlobIdFile = <TData = Awaited<ReturnType<typeof getApiBucketsBucketIdBlobsBlobIdFile>>, TError = AxiosError<unknown>>(
 bucketId: string,
    blobId: string, options?: { query?:UseQueryOptions<Awaited<ReturnType<typeof getApiBucketsBucketIdBlobsBlobIdFile>>, TError, TData>, axios?: AxiosRequestConfig}

  ):  UseQueryResult<TData, TError> & { queryKey: QueryKey } => {

  const queryOptions = getGetApiBucketsBucketIdBlobsBlobIdFileQueryOptions(bucketId,blobId,options)

  const query = useQuery(queryOptions) as  UseQueryResult<TData, TError> & { queryKey: QueryKey };

  query.queryKey = queryOptions.queryKey ;

  return query;
}


