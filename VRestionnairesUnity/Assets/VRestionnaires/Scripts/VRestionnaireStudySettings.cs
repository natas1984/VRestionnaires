﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace VRestionnaire {

	[CreateAssetMenu(menuName = "VRestionnaire Study Settings")]
	public class VRestionnaireStudySettings: ScriptableObject {

		[Serializable]
		public class QuestionnaireFromFile {
			public string condition;
			//public string[] filePaths;
			public int currentQuestionnaire;
			public TextAsset[] questionnaires;
		}


		//[Serializable]
		//public class QuestionnaireFromEditor {
		//	public string condition;
		//	public Questionnaire questionnaire;
		//}

		[Space]
		public string[] conditions;
		//public bool assignRandomCondition;
		//public bool generateParticipantId;

		[Space]
		//public bool loadQuestionnairesFromFiles;
		public QuestionnaireFromFile[] questionnairesFromFiles;
		//public QuestionnaireFromEditor[] questionnairesFromEditor;

		[Space]
		public string navigationButtonNextLabel = "Next";
		public string navigationButtonBackLabel = "Back";
		public string submitButtonLabel = "Submit";
		public string submitThankYouText = "Thank you for your participation!";

		[Space]
		public bool showQuestionId = false;
		public bool showQuestionnaireHeader = true;
		public bool questionnaireHeaderAs1stQuestion = true;
		
		[Space]
		public string answersOutputFilePath = "Assets/VRestionnaires/Resources/Answers/";



		public TextAsset[] QuestionnaireFilesForCondition(string condition)
		{
			for(int i = 0; i < questionnairesFromFiles.Length; i++) {
				if(questionnairesFromFiles[i].condition == condition) {
					return questionnairesFromFiles[i].questionnaires;
				}
			}
			return null;
		}

		//public string[] FilePathsForCondition(string condition) {
		//	for(int i = 0; i < questionnairesFromFiles.Length; i++) {
		//		if(questionnairesFromFiles[i].condition == condition) {
		//			return questionnairesFromFiles[i].filePaths;
		//		}
		//	}
		//	return null;
		//}

		private void OnValidate()
		{
			Array.Resize(ref questionnairesFromFiles, conditions.Length);
			for(int i = 0; i < conditions.Length; i++) {


				if(questionnairesFromFiles[i] == null) {
					QuestionnaireFromFile fromFile = new QuestionnaireFromFile();
					fromFile.condition = conditions[i];
					//fromFile.filePaths = new string[] { };
					fromFile.questionnaires = new TextAsset[] { };
				} else {
					questionnairesFromFiles[i].condition = conditions[i];
				}
			}
		}

	}

}
