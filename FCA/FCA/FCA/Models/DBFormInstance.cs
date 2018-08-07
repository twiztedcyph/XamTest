using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace FCA.Models
{
    public class DBFormInstance
    {
        public const string ALIAS_PREFIX = "FCINSTANCE__";


        public bool IsFormField(DBFormField Field, string TargetName)
        {
            return Field.FieldName.ToUpper() == (ALIAS_PREFIX + TargetName).ToUpper();
        }

        [PrimaryKey]
        public string FormInstanceID { get; set; }
        public string FormType { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string OwnedBy { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string DefaultTrIdent { get; set; }
        public string DefaultApIdent { get; set; }
        public string DefaultOrgRecGuid { get; set; }
        
        public void SetSignatureFileGUID(RequiredSignature type, string GUID)
        {
            switch (type)
            {
                case RequiredSignature.rsUser:
                    UserSignatureFileGUID = GUID;
                    break;
                case RequiredSignature.rsLearner:
                    LearnerSignatureFileGUID = GUID;
                    break;
                case RequiredSignature.rsEmployer:
                    EmpSignatureFileGUID = GUID;
                    break;
                case RequiredSignature.rsEmployerB:
                    EmpBSignatureFileGUID = GUID;
                    break;
                case RequiredSignature.rsEmployerC:
                    EmpCSignatureFileGUID = GUID;
                    break;
                case RequiredSignature.rsOfficerA:
                    OfficerASignatureFileGUID = GUID;
                    break;
                case RequiredSignature.rsOfficerB:
                    OfficerBSignatureFileGUID = GUID;
                    break;
                case RequiredSignature.rsNoSig:
                    break;
                default:
                    break;
            }
        }

        public string GetSignatureFileGUID(RequiredSignature type)
        {
            string GUID = string.Empty;
            switch (type)
            {
                case RequiredSignature.rsUser:
                    GUID = UserSignatureFileGUID;
                    break;
                case RequiredSignature.rsLearner:
                    GUID = LearnerSignatureFileGUID;
                    break;
                case RequiredSignature.rsEmployer:
                    GUID = EmpSignatureFileGUID;
                    break;
                case RequiredSignature.rsEmployerB:
                    GUID = EmpBSignatureFileGUID;
                    break;
                case RequiredSignature.rsEmployerC:
                    GUID = EmpCSignatureFileGUID;
                    break;
                case RequiredSignature.rsOfficerA:
                    GUID = OfficerASignatureFileGUID;
                    break;
                case RequiredSignature.rsOfficerB:
                    GUID = OfficerBSignatureFileGUID;
                    break;
                case RequiredSignature.rsNoSig:
                    break;
                default:
                    break;
            }
            return GUID;
        }


        public void SetSignaturePath(RequiredSignature type, string Path)
        {
            switch (type)
            {
                case RequiredSignature.rsUser:
                    UserSignatureData = Path;
                    break;
                case RequiredSignature.rsLearner:
                    LearnerSignatureData = Path;
                    break;
                case RequiredSignature.rsEmployer:
                    EmpSignatureData = Path;
                    break;
                case RequiredSignature.rsEmployerB:
                    EmpBSignatureData = Path;
                    break;
                case RequiredSignature.rsEmployerC:
                    EmpCSignatureData = Path;
                    break;
                case RequiredSignature.rsOfficerA:
                    OfficerASignatureData = Path;
                    break;
                case RequiredSignature.rsOfficerB:
                    OfficerBSignatureData = Path;
                    break;
                case RequiredSignature.rsNoSig:
                    break;
                default:
                    break;
            }
        }

        public string GetSignaturePath(RequiredSignature type)
        {
            string Path = string.Empty;
            switch (type)
            {
                case RequiredSignature.rsUser:
                    Path = UserSignatureData;
                    break;
                case RequiredSignature.rsLearner:
                    Path = LearnerSignatureData;
                    break;
                case RequiredSignature.rsEmployer:
                    Path = EmpSignatureData;
                    break;
                case RequiredSignature.rsEmployerB:
                    Path = EmpBSignatureData;
                    break;
                case RequiredSignature.rsEmployerC:
                    Path = EmpCSignatureData;
                    break;
                case RequiredSignature.rsOfficerA:
                    Path = OfficerASignatureData;
                    break;
                case RequiredSignature.rsOfficerB:
                    Path = OfficerBSignatureData;
                    break;
                case RequiredSignature.rsNoSig:
                    break;
                default:
                    break;
            }
            return Path;
        }

        public string UserSignatureFileGUID { get; set; }
        //ToDo: Rename to UserSignatureFilePath
        public string UserSignatureData { get; set; }

        public string LearnerSignatureFileGUID { get; set; }
        //ToDo: Rename to LearnerSignatureFilePath
        public string LearnerSignatureData { get; set; }

        public string EmpSignatureFileGUID { get; set; }
        //ToDo: Rename to EmpSignatureFilePath
        public string EmpSignatureData { get; set; }

        public string SignedDocData { get; set; }

        public string CustomFormID { get; set; }
        
        public DateTime LastUploaded { get; set; }
        public string LastUploadStatus { get; set; }
        public string OriginatingForm { get; set; }
        public string CreateVersion { get; set; }
        public string LastModVersion { get; set; }
        public DateTime Due { get; set; }
        public string HOFeedBack { get; set; }
        public string SourceApplicID { get; set; }
        public int SourceCRMEventID { get; set; }

        private Dictionary<string, DBFormField> _fields;
        [Ignore]
        public Dictionary<string, DBFormField> Fields
        {
            get
            {
                if (_fields == null)
                    _fields = new Dictionary<string, DBFormField>();
                return _fields;
            }
            set
            {
                _fields = value;
            }
        }

        private List<DBFormInstanceAttachment> _attachments;
        [Ignore]
        public List<DBFormInstanceAttachment> Attachments
        {
            get
            {
                if (_attachments == null)
                    _attachments = new List<DBFormInstanceAttachment>();
                return _attachments;
            }
            set
            {
                _attachments = value;
            }
        }


        [Ignore]
        public string CustomFormTypeTitle { get; set; }
        [Ignore]
        public string StatusText { get; set; }
        public string EmpBSignatureFileGUID { get; set; }
        public string EmpCSignatureFileGUID { get; set; }
        public string OfficerASignatureFileGUID { get; set; }
        public string OfficerBSignatureFileGUID { get; set; }
        public string EmpBSignatureData { get; set; }
        public string EmpCSignatureData { get; set; }
        public string OfficerASignatureData { get; set; }
        public string OfficerBSignatureData { get; set; }

        public void UpdateInstanceField(string fieldName, string fieldValue, string fieldType)
        {
            DBFormField fld = null;
            if (Fields.Count > 0 && Fields.ContainsKey(ALIAS_PREFIX + fieldName.ToUpper()))
            {
                fld = Fields[ALIAS_PREFIX + fieldName];
                fld.FieldValue = fieldValue;
                fld.FieldType = fieldType;
            }
            else
            {
                //Create Field
                fld = new DBFormField();
                fld.FieldName = ALIAS_PREFIX + fieldName.ToUpper();
                fld.FieldValue = fieldValue;
                fld.FieldType = fieldType;
                fld.FormInstanceID = this.FormInstanceID;
                fld.RecGUID = fld.FormInstanceID + fld.FieldName;
                Fields.Add(fld.FieldName, fld);
            }
        }
    }
}
