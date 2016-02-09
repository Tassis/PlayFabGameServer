using System;
using PlayFab.Json;
using PlayFab.ServerModels;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab
{
    /// <summary>
    /// Provides functionality to allow external (developer-controlled) servers to interact with user inventories and data in a trusted manner, and to handle matchmaking and client connection orchestration
    /// </summary>
    public static class PlayFabServerAPI
    {
        public delegate void AuthenticateSessionTicketCallback(AuthenticateSessionTicketResult result);
        public delegate void GetPlayFabIDsFromFacebookIDsCallback(GetPlayFabIDsFromFacebookIDsResult result);
        public delegate void GetUserAccountInfoCallback(GetUserAccountInfoResult result);
        public delegate void SendPushNotificationCallback(SendPushNotificationResult result);
        public delegate void DeleteUsersCallback(DeleteUsersResult result);
        public delegate void GetLeaderboardCallback(GetLeaderboardResult result);
        public delegate void GetLeaderboardAroundUserCallback(GetLeaderboardAroundUserResult result);
        public delegate void GetUserDataCallback(GetUserDataResult result);
        public delegate void GetUserInternalDataCallback(GetUserDataResult result);
        public delegate void GetUserPublisherDataCallback(GetUserDataResult result);
        public delegate void GetUserPublisherInternalDataCallback(GetUserDataResult result);
        public delegate void GetUserPublisherReadOnlyDataCallback(GetUserDataResult result);
        public delegate void GetUserReadOnlyDataCallback(GetUserDataResult result);
        public delegate void GetUserStatisticsCallback(GetUserStatisticsResult result);
        public delegate void UpdateUserDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserInternalDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserPublisherDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserPublisherInternalDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserPublisherReadOnlyDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserReadOnlyDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserStatisticsCallback(UpdateUserStatisticsResult result);
        public delegate void GetCatalogItemsCallback(GetCatalogItemsResult result);
        public delegate void GetTitleDataCallback(GetTitleDataResult result);
        public delegate void GetTitleInternalDataCallback(GetTitleDataResult result);
        public delegate void GetTitleNewsCallback(GetTitleNewsResult result);
        public delegate void SetTitleDataCallback(SetTitleDataResult result);
        public delegate void SetTitleInternalDataCallback(SetTitleDataResult result);
        public delegate void AddCharacterVirtualCurrencyCallback(ModifyCharacterVirtualCurrencyResult result);
        public delegate void AddUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
        public delegate void ConsumeItemCallback(ConsumeItemResult result);
        public delegate void GetCharacterInventoryCallback(GetCharacterInventoryResult result);
        public delegate void GetUserInventoryCallback(GetUserInventoryResult result);
        public delegate void GrantItemsToCharacterCallback(GrantItemsToCharacterResult result);
        public delegate void GrantItemsToUserCallback(GrantItemsToUserResult result);
        public delegate void GrantItemsToUsersCallback(GrantItemsToUsersResult result);
        public delegate void ModifyItemUsesCallback(ModifyItemUsesResult result);
        public delegate void MoveItemToCharacterFromCharacterCallback(MoveItemToCharacterFromCharacterResult result);
        public delegate void MoveItemToCharacterFromUserCallback(MoveItemToCharacterFromUserResult result);
        public delegate void MoveItemToUserFromCharacterCallback(MoveItemToUserFromCharacterResult result);
        public delegate void RedeemCouponCallback(RedeemCouponResult result);
        public delegate void ReportPlayerCallback(ReportPlayerServerResult result);
        public delegate void RevokeInventoryItemCallback(RevokeInventoryResult result);
        public delegate void SubtractCharacterVirtualCurrencyCallback(ModifyCharacterVirtualCurrencyResult result);
        public delegate void SubtractUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
        public delegate void UpdateUserInventoryItemCustomDataCallback(UpdateUserInventoryItemDataResult result);
        public delegate void NotifyMatchmakerPlayerLeftCallback(NotifyMatchmakerPlayerLeftResult result);
        public delegate void RedeemMatchmakerTicketCallback(RedeemMatchmakerTicketResult result);
        public delegate void AwardSteamAchievementCallback(AwardSteamAchievementResult result);
        public delegate void LogEventCallback(LogEventResult result);
        public delegate void AddSharedGroupMembersCallback(AddSharedGroupMembersResult result);
        public delegate void CreateSharedGroupCallback(CreateSharedGroupResult result);
        public delegate void DeleteSharedGroupCallback(EmptyResult result);
        public delegate void GetPublisherDataCallback(GetPublisherDataResult result);
        public delegate void GetSharedGroupDataCallback(GetSharedGroupDataResult result);
        public delegate void RemoveSharedGroupMembersCallback(RemoveSharedGroupMembersResult result);
        public delegate void SetPublisherDataCallback(SetPublisherDataResult result);
        public delegate void UpdateSharedGroupDataCallback(UpdateSharedGroupDataResult result);
        public delegate void GetContentDownloadUrlCallback(GetContentDownloadUrlResult result);
        public delegate void DeleteCharacterFromUserCallback(DeleteCharacterFromUserResult result);
        public delegate void GetAllUsersCharactersCallback(ListUsersCharactersResult result);
        public delegate void GetCharacterLeaderboardCallback(GetCharacterLeaderboardResult result);
        public delegate void GetCharacterStatisticsCallback(GetCharacterStatisticsResult result);
        public delegate void GetLeaderboardAroundCharacterCallback(GetLeaderboardAroundCharacterResult result);
        public delegate void GetLeaderboardForUserCharactersCallback(GetLeaderboardForUsersCharactersResult result);
        public delegate void GrantCharacterToUserCallback(GrantCharacterToUserResult result);
        public delegate void UpdateCharacterStatisticsCallback(UpdateCharacterStatisticsResult result);
        public delegate void GetCharacterDataCallback(GetCharacterDataResult result);
        public delegate void GetCharacterInternalDataCallback(GetCharacterDataResult result);
        public delegate void GetCharacterReadOnlyDataCallback(GetCharacterDataResult result);
        public delegate void UpdateCharacterDataCallback(UpdateCharacterDataResult result);
        public delegate void UpdateCharacterInternalDataCallback(UpdateCharacterDataResult result);
        public delegate void UpdateCharacterReadOnlyDataCallback(UpdateCharacterDataResult result);


        /// <summary>
        /// Validated a client's session ticket, and if successful, returns details for that user
        /// </summary>
        public static void AuthenticateSessionTicket(AuthenticateSessionTicketRequest request, AuthenticateSessionTicketCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                AuthenticateSessionTicketResult result = ResultContainer<AuthenticateSessionTicketResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/AuthenticateSessionTicket", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromFacebookIDs(GetPlayFabIDsFromFacebookIDsRequest request, GetPlayFabIDsFromFacebookIDsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetPlayFabIDsFromFacebookIDsResult result = ResultContainer<GetPlayFabIDsFromFacebookIDsResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetPlayFabIDsFromFacebookIDs", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user
        /// </summary>
        public static void GetUserAccountInfo(GetUserAccountInfoRequest request, GetUserAccountInfoCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetUserAccountInfoResult result = ResultContainer<GetUserAccountInfoResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetUserAccountInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        public static void SendPushNotification(SendPushNotificationRequest request, SendPushNotificationCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                SendPushNotificationResult result = ResultContainer<SendPushNotificationResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/SendPushNotification", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
        /// </summary>
        public static void DeleteUsers(DeleteUsersRequest request, DeleteUsersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                DeleteUsersResult result = ResultContainer<DeleteUsersResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/DeleteUsers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetLeaderboard(GetLeaderboardRequest request, GetLeaderboardCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetLeaderboardResult result = ResultContainer<GetLeaderboardResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetLeaderboard", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
        /// </summary>
        public static void GetLeaderboardAroundUser(GetLeaderboardAroundUserRequest request, GetLeaderboardAroundUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetLeaderboardAroundUserResult result = ResultContainer<GetLeaderboardAroundUserResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetLeaderboardAroundUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, GetUserDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetUserDataResult result = ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetUserData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserInternalData(GetUserDataRequest request, GetUserInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetUserDataResult result = ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetUserInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, GetUserPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetUserDataResult result = ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetUserPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserPublisherInternalData(GetUserDataRequest request, GetUserPublisherInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetUserDataResult result = ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetUserPublisherInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, GetUserPublisherReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetUserDataResult result = ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetUserPublisherReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, GetUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetUserDataResult result = ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetUserReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the user
        /// </summary>
        public static void GetUserStatistics(GetUserStatisticsRequest request, GetUserStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetUserStatisticsResult result = ResultContainer<GetUserStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetUserStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, UpdateUserDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateUserDataResult result = ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateUserData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, UpdateUserInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateUserDataResult result = ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateUserInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, UpdateUserPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateUserDataResult result = ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateUserPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserPublisherInternalData(UpdateUserInternalDataRequest request, UpdateUserPublisherInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateUserDataResult result = ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateUserPublisherInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserPublisherReadOnlyData(UpdateUserDataRequest request, UpdateUserPublisherReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateUserDataResult result = ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateUserPublisherReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, UpdateUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateUserDataResult result = ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateUserReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user
        /// </summary>
        public static void UpdateUserStatistics(UpdateUserStatisticsRequest request, UpdateUserStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateUserStatisticsResult result = ResultContainer<UpdateUserStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateUserStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, GetCatalogItemsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetCatalogItemsResult result = ResultContainer<GetCatalogItemsResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetCatalogItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, GetTitleDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetTitleDataResult result = ResultContainer<GetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetTitleData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom internal title settings
        /// </summary>
        public static void GetTitleInternalData(GetTitleDataRequest request, GetTitleInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetTitleDataResult result = ResultContainer<GetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetTitleInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        public static void GetTitleNews(GetTitleNewsRequest request, GetTitleNewsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetTitleNewsResult result = ResultContainer<GetTitleNewsResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetTitleNews", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        public static void SetTitleData(SetTitleDataRequest request, SetTitleDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                SetTitleDataResult result = ResultContainer<SetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/SetTitleData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        public static void SetTitleInternalData(SetTitleDataRequest request, SetTitleInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                SetTitleDataResult result = ResultContainer<SetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/SetTitleInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Increments  the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void AddCharacterVirtualCurrency(AddCharacterVirtualCurrencyRequest request, AddCharacterVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ModifyCharacterVirtualCurrencyResult result = ResultContainer<ModifyCharacterVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/AddCharacterVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Increments  the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, AddUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ModifyUserVirtualCurrencyResult result = ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/AddUserVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
        /// </summary>
        public static void ConsumeItem(ConsumeItemRequest request, ConsumeItemCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ConsumeItemResult result = ResultContainer<ConsumeItemResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/ConsumeItem", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        public static void GetCharacterInventory(GetCharacterInventoryRequest request, GetCharacterInventoryCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetCharacterInventoryResult result = ResultContainer<GetCharacterInventoryResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetCharacterInventory", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, GetUserInventoryCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetUserInventoryResult result = ResultContainer<GetUserInventoryResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetUserInventory", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified character's inventory
        /// </summary>
        public static void GrantItemsToCharacter(GrantItemsToCharacterRequest request, GrantItemsToCharacterCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GrantItemsToCharacterResult result = ResultContainer<GrantItemsToCharacterResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GrantItemsToCharacter", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified user's inventory
        /// </summary>
        public static void GrantItemsToUser(GrantItemsToUserRequest request, GrantItemsToUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GrantItemsToUserResult result = ResultContainer<GrantItemsToUserResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GrantItemsToUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        public static void GrantItemsToUsers(GrantItemsToUsersRequest request, GrantItemsToUsersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GrantItemsToUsersResult result = ResultContainer<GrantItemsToUsersResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GrantItemsToUsers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Modifies the number of remaining uses of a player's inventory item
        /// </summary>
        public static void ModifyItemUses(ModifyItemUsesRequest request, ModifyItemUsesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ModifyItemUsesResult result = ResultContainer<ModifyItemUsesResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/ModifyItemUses", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Moves an item from a character's inventory into another of the users's character's inventory.
        /// </summary>
        public static void MoveItemToCharacterFromCharacter(MoveItemToCharacterFromCharacterRequest request, MoveItemToCharacterFromCharacterCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                MoveItemToCharacterFromCharacterResult result = ResultContainer<MoveItemToCharacterFromCharacterResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/MoveItemToCharacterFromCharacter", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Moves an item from a user's inventory into their character's inventory.
        /// </summary>
        public static void MoveItemToCharacterFromUser(MoveItemToCharacterFromUserRequest request, MoveItemToCharacterFromUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                MoveItemToCharacterFromUserResult result = ResultContainer<MoveItemToCharacterFromUserResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/MoveItemToCharacterFromUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Moves an item from a character's inventory into the owning user's inventory.
        /// </summary>
        public static void MoveItemToUserFromCharacter(MoveItemToUserFromCharacterRequest request, MoveItemToUserFromCharacterCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                MoveItemToUserFromCharacterResult result = ResultContainer<MoveItemToUserFromCharacterResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/MoveItemToUserFromCharacter", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the Promotions->Coupons tab in the PlayFab Game Manager. See this post for more information on coupons:  https://playfab.com/blog/2015/06/18/using-stores-and-coupons-game-manager
        /// </summary>
        public static void RedeemCoupon(RedeemCouponRequest request, RedeemCouponCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                RedeemCouponResult result = ResultContainer<RedeemCouponResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/RedeemCoupon", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service representatives for the title can take action concerning potentially toxic players.
        /// </summary>
        public static void ReportPlayer(ReportPlayerServerRequest request, ReportPlayerCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ReportPlayerServerResult result = ResultContainer<ReportPlayerServerResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/ReportPlayer", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        public static void RevokeInventoryItem(RevokeInventoryItemRequest request, RevokeInventoryItemCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                RevokeInventoryResult result = ResultContainer<RevokeInventoryResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/RevokeInventoryItem", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Decrements the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractCharacterVirtualCurrency(SubtractCharacterVirtualCurrencyRequest request, SubtractCharacterVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ModifyCharacterVirtualCurrencyResult result = ResultContainer<ModifyCharacterVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/SubtractCharacterVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, SubtractUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ModifyUserVirtualCurrencyResult result = ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/SubtractUserVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
        /// </summary>
        public static void UpdateUserInventoryItemCustomData(UpdateUserInventoryItemDataRequest request, UpdateUserInventoryItemCustomDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateUserInventoryItemDataResult result = ResultContainer<UpdateUserInventoryItemDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateUserInventoryItemCustomData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
        /// </summary>
        public static void NotifyMatchmakerPlayerLeft(NotifyMatchmakerPlayerLeftRequest request, NotifyMatchmakerPlayerLeftCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                NotifyMatchmakerPlayerLeftResult result = ResultContainer<NotifyMatchmakerPlayerLeftResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/NotifyMatchmakerPlayerLeft", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Validates a Game Server session ticket and returns details about the user
        /// </summary>
        public static void RedeemMatchmakerTicket(RedeemMatchmakerTicketRequest request, RedeemMatchmakerTicketCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                RedeemMatchmakerTicketResult result = ResultContainer<RedeemMatchmakerTicketResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/RedeemMatchmakerTicket", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Awards the specified users the specified Steam achievements
        /// </summary>
        public static void AwardSteamAchievement(AwardSteamAchievementRequest request, AwardSteamAchievementCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                AwardSteamAchievementResult result = ResultContainer<AwardSteamAchievementResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/AwardSteamAchievement", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Logs a custom analytics event
        /// </summary>
        public static void LogEvent(LogEventRequest request, LogEventCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                LogEventResult result = ResultContainer<LogEventResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/LogEvent", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group (and the server) can add new members.
        /// </summary>
        public static void AddSharedGroupMembers(AddSharedGroupMembersRequest request, AddSharedGroupMembersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                AddSharedGroupMembersResult result = ResultContainer<AddSharedGroupMembersResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/AddSharedGroupMembers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. When created by a server, the group will initially have no members.
        /// </summary>
        public static void CreateSharedGroup(CreateSharedGroupRequest request, CreateSharedGroupCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                CreateSharedGroupResult result = ResultContainer<CreateSharedGroupResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/CreateSharedGroup", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Deletes a shared group, freeing up the shared group ID to be reused for a new group
        /// </summary>
        public static void DeleteSharedGroup(DeleteSharedGroupRequest request, DeleteSharedGroupCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                EmptyResult result = ResultContainer<EmptyResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/DeleteSharedGroup", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, GetPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetPublisherDataResult result = ResultContainer<GetPublisherDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all public and private group data.
        /// </summary>
        public static void GetSharedGroupData(GetSharedGroupDataRequest request, GetSharedGroupDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetSharedGroupDataResult result = ResultContainer<GetSharedGroupDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetSharedGroupData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
        /// </summary>
        public static void RemoveSharedGroupMembers(RemoveSharedGroupMembersRequest request, RemoveSharedGroupMembersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                RemoveSharedGroupMembersResult result = ResultContainer<RemoveSharedGroupMembersResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/RemoveSharedGroupMembers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public static void SetPublisherData(SetPublisherDataRequest request, SetPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                SetPublisherDataResult result = ResultContainer<SetPublisherDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/SetPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group (and the server) can update the data.
        /// </summary>
        public static void UpdateSharedGroupData(UpdateSharedGroupDataRequest request, UpdateSharedGroupDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateSharedGroupDataResult result = ResultContainer<UpdateSharedGroupDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateSharedGroupData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://support.playfab.com/support/discussions/topics/1000059929
        /// </summary>
        public static void GetContentDownloadUrl(GetContentDownloadUrlRequest request, GetContentDownloadUrlCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetContentDownloadUrlResult result = ResultContainer<GetContentDownloadUrlResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetContentDownloadUrl", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Deletes the specific character ID from the specified user.
        /// </summary>
        public static void DeleteCharacterFromUser(DeleteCharacterFromUserRequest request, DeleteCharacterFromUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                DeleteCharacterFromUserResult result = ResultContainer<DeleteCharacterFromUserResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/DeleteCharacterFromUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Lists all of the characters that belong to a specific user.
        /// </summary>
        public static void GetAllUsersCharacters(ListUsersCharactersRequest request, GetAllUsersCharactersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ListUsersCharactersResult result = ResultContainer<ListUsersCharactersResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetAllUsersCharacters", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetCharacterLeaderboard(GetCharacterLeaderboardRequest request, GetCharacterLeaderboardCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetCharacterLeaderboardResult result = ResultContainer<GetCharacterLeaderboardResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetCharacterLeaderboard", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the specific character
        /// </summary>
        public static void GetCharacterStatistics(GetCharacterStatisticsRequest request, GetCharacterStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetCharacterStatisticsResult result = ResultContainer<GetCharacterStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetCharacterStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested user
        /// </summary>
        public static void GetLeaderboardAroundCharacter(GetLeaderboardAroundCharacterRequest request, GetLeaderboardAroundCharacterCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetLeaderboardAroundCharacterResult result = ResultContainer<GetLeaderboardAroundCharacterResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetLeaderboardAroundCharacter", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        public static void GetLeaderboardForUserCharacters(GetLeaderboardForUsersCharactersRequest request, GetLeaderboardForUserCharactersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetLeaderboardForUsersCharactersResult result = ResultContainer<GetLeaderboardForUsersCharactersResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetLeaderboardForUserCharacters", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Grants the specified character type to the user.
        /// </summary>
        public static void GrantCharacterToUser(GrantCharacterToUserRequest request, GrantCharacterToUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GrantCharacterToUserResult result = ResultContainer<GrantCharacterToUserResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GrantCharacterToUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character
        /// </summary>
        public static void UpdateCharacterStatistics(UpdateCharacterStatisticsRequest request, UpdateCharacterStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateCharacterStatisticsResult result = ResultContainer<UpdateCharacterStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateCharacterStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetCharacterData(GetCharacterDataRequest request, GetCharacterDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetCharacterDataResult result = ResultContainer<GetCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetCharacterData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        public static void GetCharacterInternalData(GetCharacterDataRequest request, GetCharacterInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetCharacterDataResult result = ResultContainer<GetCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetCharacterInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        public static void GetCharacterReadOnlyData(GetCharacterDataRequest request, GetCharacterReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                GetCharacterDataResult result = ResultContainer<GetCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/GetCharacterReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's chjaracter which is readable and writable by the client
        /// </summary>
        public static void UpdateCharacterData(UpdateCharacterDataRequest request, UpdateCharacterDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateCharacterDataResult result = ResultContainer<UpdateCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateCharacterData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's character which cannot  be accessed by the client
        /// </summary>
        public static void UpdateCharacterInternalData(UpdateCharacterDataRequest request, UpdateCharacterInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateCharacterDataResult result = ResultContainer<UpdateCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateCharacterInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        public static void UpdateCharacterReadOnlyData(UpdateCharacterDataRequest request, UpdateCharacterReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                UpdateCharacterDataResult result = ResultContainer<UpdateCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback);
                if (result != null)
                {

                }
            };
            PlayFabHTTP.Post("/Server/UpdateCharacterReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }


    }
}